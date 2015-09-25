using System.Web.Mvc;
using Application.MainModule.DTO;
using Application.MainModule.Interfaces;
using Infrastructure.CrossCutting.Enums;
using Presentation.Aspects;
using Presentation.Core;

namespace Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFiguraAppService _figuraAppService;

        public HomeController(IFiguraAppService figuraAppService)
        {
            _figuraAppService = figuraAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [ActionController(ActionType.Post)]
        [HttpPostAction(TipoPermiso.Ninguno)]
        public JsonResult Crear(FiguraDto figuraDto)
        {
            var jsonResponse = new JsonResponse {Success = false};
            var respuesta = _figuraAppService.Create(figuraDto);

            jsonResponse.Success = respuesta.IsValid;
            jsonResponse.Message = respuesta.ErrorMessage();

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }
    }
}