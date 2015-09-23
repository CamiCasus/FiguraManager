using Application.MainModule.DTO;
using Application.MainModule.Interfaces;
using Infrastructure.CrossCutting.Enums;
using Presentation.Aspects;
using Presentation.Core;
using Presentation.Web.Controllers;
using Presentation.Web.Resources;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Presentation.Web.Areas.Administracion.Controllers
{
    public class FormularioController : BaseWebController
    {
        #region Members

        private readonly IFormularioAppService _formularioAppService;
        private readonly IRolAppService _rolAppService;
        
        #endregion

        #region Constructor

        public FormularioController(IFormularioAppService formularioAppService, IRolAppService rolAppService)
        {
            _formularioAppService = formularioAppService;
            _rolAppService = rolAppService;
        }
        
        #endregion

        #region Actions

        [ActionController(ActionType.Get)]
        [HttpGetAction(TipoPermiso.Mostrar)]
        public ActionResult Index()
        {
            var formularios = _formularioAppService.AllToTree();
            foreach (var item in formularios)
            {
                item.ResourceKey = MenuResources.Traduccion(item.ResourceKey);
                item.FormulariosHijosList.ForEach(p => p.ResourceKey = MenuResources.Traduccion(p.ResourceKey));
            }

            var model = new AsignarPermisoDto
            {
                FormularioList = formularios,
                RolList = _rolAppService.GetActivosOrdenadosPorNombre().ToList()
            };
            return View(model);
        }

        [ActionController(ActionType.Post)]
        [HttpPostAction(TipoPermiso.Ninguno)]
        public JsonResult ObtenerPermisos(string idFormulario, string idRol)
        {
            var model = new PermisoRolDto
            {
                FormularioId = Convert.ToInt32(idFormulario),
                RolId = Convert.ToInt32(idRol)
            };

            _formularioAppService.ObtenerPermisos(model);

            model.NombreFormulario = MenuResources.Traduccion(model.NombreFormulario);

            var response = new JsonResponse
            {
                Data = model,
                Success = true
            };
            return Json(response);
        }

        [ActionController(ActionType.Post)]
        [HttpPostAction(TipoPermiso.Editar)]
        public JsonResult ActualizarPermisos(PermisoRolDto model)
        {
            _formularioAppService.ActualizarPermisos(model);

            var response = new JsonResponse
            {
                Success = true,
                Message = FormularioResources.Mensaje
            };
            return Json(response);
        } 

        #endregion
    }
}