using Application.MainModule.DTO;
using Infrastructure.CrossCutting.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Presentation.Core
{
    public class WebSessionFilter : ActionFilterAttribute
    {
        private Controller _controllerActual;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _controllerActual = filterContext.Controller as Controller;

            var actionName = filterContext.RouteData.Values["action"].ToString();
            var controllerName = filterContext.RouteData.Values["controller"].ToString();
            var area = filterContext.RouteData.DataTokens["area"] != null
                ? filterContext.RouteData.DataTokens["area"].ToString()
                : string.Empty;


            if (String.Compare(controllerName, Constantes.LoginController, StringComparison.Ordinal) != 0 &&
                String.Compare(actionName.ToLowerInvariant(), Constantes.LoginAction, StringComparison.Ordinal) != 0)
            {
                if (WebSession.Usuario == null)
                {
                    filterContext.Result =
                        new RedirectToRouteResult(
                            new RouteValueDictionary(
                                new
                                {
                                    area = string.Empty,
                                    controller = Constantes.LoginController,
                                    action = Constantes.LoginAction
                                }));
                    return;
                }


                if (WebSession.Formularios != null)
                {
                    var formulariosHijos = WebSession.Formularios.SelectMany(p => p.FormulariosHijosList);

                    FormularioDto formularioActual = null;
                    var verb = filterContext.HttpContext.Request.HttpMethod;
                    var permisoActual = GetPermisoAction(actionName, filterContext.Controller, verb);

                    if (permisoActual != TipoPermiso.Ninguno)
                    {
                        var formulariosEncontradosPorControlador =
                            formulariosHijos.Where(
                                p =>
                                    String.Compare(p.Area, area, StringComparison.Ordinal) == 0 &&
                                    String.Compare(p.Controlador, controllerName,
                                        StringComparison.Ordinal) == 0 &&
                                    p.PermisoList.Any(q => q.TipoPermiso == (int)permisoActual));

                        var encontradosPorControlador = formulariosEncontradosPorControlador as IList<FormularioDto> ??
                                                        formulariosEncontradosPorControlador.ToList();

                        if (encontradosPorControlador.Any())
                        {
                            formularioActual = encontradosPorControlador.FirstOrDefault();
                            SetViewbagPermisosValidosFormulario(formularioActual);
                        }
                        else
                        {
                            filterContext.Result = HandlerUnauthorizationResponse(verb, controllerName, area, actionName);
                        }
                    }

                    WebSession.FormularioActual = formularioActual;
                }
                WebSession.FormularioActual = WebSession.FormularioActual ?? new FormularioDto();
            }

            base.OnActionExecuting(filterContext);
        }

        private void SetViewbagPermisosValidosFormulario(FormularioDto formulario)
        {
            var listaPermisosValidos =
                formulario.PermisoList.Select(p => (TipoPermiso)Enum.Parse(typeof(TipoPermiso), p.TipoPermiso.ToString()));

            _controllerActual.ViewBag.PermisosValidos = listaPermisosValidos;
        }

        private RouteValueDictionary GetRedirectActionUnauthorized(string controllerActual, string areaActual, string accion)
        {
            var indexMethod = _controllerActual.GetType().GetMethod("Index");
            if (indexMethod != null && accion != indexMethod.Name)
            {
                return new RouteValueDictionary(
                    new
                    {
                        area = areaActual,
                        controller = controllerActual,
                        action = indexMethod.Name,
                        state = Constantes.Unauthorized
                    });
            }

            return new RouteValueDictionary(
                new
                {
                    area = "",
                    controller = "Error",
                    action = "Index",
                    state = Constantes.Unauthorized
                });
        }

        private TipoPermiso GetPermisoAction(string actionName, ControllerBase controller, string verb)
        {
            var methodInfo = controller.GetType().GetMethods().FirstOrDefault(p =>
                p.Name == actionName &&
                p.CustomAttributes.Any(
                    q =>
                        verb == HttpVerbs.Get.ToString().ToUpperInvariant()
                            ? q.AttributeType == typeof (HttpGetAction)
                            : q.AttributeType == typeof (HttpPostAction)));

            if (methodInfo == null)
                throw new Exception("No se ha asignado los atributos correspondientes en el controlador....");

            var attributePermiso = methodInfo.GetCustomAttributes(typeof (IPermiso), true).FirstOrDefault() as IPermiso;
            return attributePermiso.GetPermiso();
        }

        private ActionResult HandlerUnauthorizationResponse(string verb, string controllerName, string area, string accion)
        {
            if (string.Compare(verb, (HttpVerbs.Get.ToString().ToUpperInvariant()), StringComparison.Ordinal) == 0)
                return new RedirectToRouteResult(GetRedirectActionUnauthorized(controllerName, area, accion));

            if (string.Compare(verb, (HttpVerbs.Post.ToString().ToUpperInvariant()), StringComparison.Ordinal) == 0)
            {
                return new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            area = string.Empty,
                            controller = Constantes.LoginController,
                            action = Constantes.LoginAction
                        }));
             
            }

            return default(ActionResult);
        }
    }
}
