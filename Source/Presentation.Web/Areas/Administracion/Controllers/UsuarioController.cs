using Application.MainModule.DTO;
using Application.MainModule.Interfaces;
using Infrastructure.CrossCutting.Enums;
using Presentation.Aspects;
using Presentation.Core;
using Presentation.Core.Syncfusion;
using Presentation.Web.Controllers;
using Syncfusion.JavaScript;
using System.Web.Mvc;

namespace Presentation.Web.Areas.Administracion.Controllers
{
    public class UsuarioController : BaseWebController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [ActionController(ActionType.Post)]
        [HttpPostAction(TipoPermiso.Ninguno)]
        public JsonResult Pagination(DataManager dm)
        {         
            var resultado =
                _usuarioAppService.FindAllPaging(
                    SyncFusionDataManagerToFilterParametersDtoConverter<UsuarioPaginationDto>.Convert(dm));

            return Json(resultado);
        }

        [ActionController(ActionType.Get)]
        [HttpGetAction(TipoPermiso.Mostrar)]
        public ActionResult Index()
        {
            return View();
        }

        [ActionController(ActionType.Get)]
        [HttpGetAction(TipoPermiso.Crear)]
        public ActionResult Crear()
        {
            var usuarioDto = _usuarioAppService.GetUsuarioDtoCrear();
            return View("Edit", usuarioDto);
        }

        [ActionController(ActionType.Post)]
        [HttpPostAction(TipoPermiso.Crear)]
        public JsonResult Crear(UsuarioDto usuario)
        {
            usuario.UsuarioRegistro = WebSession.Usuario.UserName;

            var respuestaAppService = _usuarioAppService.Create(usuario);

            var jsonResponse = CastMessageView(respuestaAppService);

            return Json(jsonResponse);
        }

        [ActionController(ActionType.Get)]
        [HttpGetAction(TipoPermiso.Editar)]
        public ActionResult Editar(int id)
        {
            var usuarioDto = _usuarioAppService.GetUsuarioDtoEditar(id);
            return View("Edit", usuarioDto);
        }

        [ActionController(ActionType.Post)]
        [HttpPostAction(TipoPermiso.Editar)]
        public JsonResult Editar(UsuarioDto usuario)
        {
            usuario.UsuarioRegistro = WebSession.Usuario.UserName;

            var respuestaAppService = _usuarioAppService.Update(usuario);

            var jsonResponse = CastMessageView(respuestaAppService);

            return Json(jsonResponse);
        }

        [ActionController(ActionType.Delete)]
        [HttpPostAction(TipoPermiso.Eliminar)]
        public JsonResult Eliminar(UsuarioDto usuario)
        {      
            var respuestaAppService = _usuarioAppService.Remove(usuario);

            var jsonResponse = CastMessageView(respuestaAppService);

            return Json(jsonResponse);
        }
    }
}