﻿using System.Web.Mvc;
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
            var figuraIndexDto = _figuraAppService.GetFiguraIndexDto();
            return View(figuraIndexDto);
        }

        [ActionController(ActionType.Post)]
        [HttpPostAction(TipoPermiso.Ninguno)]
        public JsonResult Crear(FiguraDto figuraDto)
        {
            var jsonResponse = new JsonResponse();
            var respuesta = _figuraAppService.Create(figuraDto);

            jsonResponse.Success = respuesta.IsValid;
            jsonResponse.Message = respuesta.ErrorMessage();

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }

        [ActionController(ActionType.Post)]
        [HttpPostAction(TipoPermiso.Ninguno)]
        public JsonResult ObtenerPedidosMes(string fechaInicio, string fechaFin)
        {
            var jsonResponse = new JsonResponse { Success = true };

            var coincidencias = _figuraAppService.GetPedidosRangoFechas(fechaInicio, fechaFin);

            jsonResponse.Success = true;
            jsonResponse.Data = coincidencias;

            return Json(jsonResponse, JsonRequestBehavior.AllowGet);
        }
    }
}