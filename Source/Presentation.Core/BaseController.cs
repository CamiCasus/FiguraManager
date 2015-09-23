using Application.Core;
using Infrastructure.CrossCutting.Common;
using Infrastructure.CrossCutting.Logging;
using Presentation.Core.Resources;
using System;
using System.Collections;
using System.Net;
using System.Web.Mvc;

namespace Presentation.Core
{
    [Authorize]
    [HandleError]
    [WebSessionFilter]
    public abstract class BaseController : Controller
    {
        #region Propiedades

        protected static readonly ILogger Logger = new Log4Net();

        protected DateTime FechaActual
        {
            get { return DateTime.UtcNow.ToTimeZoneTime(WebSession.Usuario.TimeZoneId); }
        }

        #endregion

        #region Constructor

        #endregion

        #region Overrides

        protected override void OnException(ExceptionContext filterContext)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];

            Logger.Error(string.Format("Controlador:{0}  Action:{1}  Mensaje:{2}", controllerName, actionName, WebUtils.GetExceptionMessage(filterContext.Exception)));

            filterContext.Result = View("Error");
        }

        protected override void HandleUnknownAction(string actionName)
        {
            RedirectToAction("Index").ExecuteResult(ControllerContext);
        }

        #endregion

        #region Métodos

        protected JsonResponse CastMessageView(ValidationResultDto validation)
        {
            var response = new JsonResponse
            {
                Success = validation.IsValid,
                Message = validation.IsValid
                    ? PresentationResources.RegistroSatisfactorio
                    : validation.ErrorMessage()
            };

            return response;
        }

        protected new ViewResult View(object model)
        {
            var actionName = ControllerContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();

            return View(actionName, model);
        }

        protected new ViewResult View(string viewName, object model)
        {
            if (model != null)
            {
                try
                {
                    if (WebSession.Usuario != null)
                    {
                        TimeZoneUtils.ChangeTimeZoneInObjectFields(model, WebSession.Usuario.TimeZoneId);
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex);
                }
            }
            return base.View(viewName, model);
        }

        protected new JsonResult Json(object data)
        {
            if (data != null)
            {
                try
                {
                    if (WebSession.Usuario != null)
                    {
                        if (data.GetType() == typeof(JsonResponse))
                        {
                            var jsonResponse = data as JsonResponse;
                            TimeZoneUtils.ChangeTimeZoneInObjectFields(jsonResponse.Data, WebSession.Usuario.TimeZoneId);
                        }
                        else if (data.GetType().GetGenericTypeDefinition() == typeof(PaginationResultDto<>))
                        {
                            var resultProperty = data.GetType().GetProperty("Entities");
                            var countProperty = data.GetType().GetProperty("Count");

                            foreach (var item in (IEnumerable)resultProperty.GetValue(data, null))
                            {
                                TimeZoneUtils.ChangeTimeZoneInObjectFields(item, WebSession.Usuario.TimeZoneId);
                            }
                            return Json(new
                            {
                                count = countProperty.GetValue(data, null),
                                result = resultProperty.GetValue(data, null)
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex);
                }
            }
            return base.Json(data);
        }

        protected void LogError(Exception exception)
        {
            Logger.Error(string.Format("Mensaje: {0} Trace: {1}", exception.Message, exception.StackTrace));
        }

        #endregion
    }
}
