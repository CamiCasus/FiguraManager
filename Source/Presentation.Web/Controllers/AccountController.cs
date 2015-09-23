using Application.MainModule.DTO;
using Application.MainModule.DTO.Resources;
using Application.MainModule.Interfaces;
using Infrastructure.CrossCutting.Common;
using Presentation.Aspects;
using Presentation.Core;
using Presentation.Core.Helpers;
using Presentation.Web.Resources;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Infrastructure.CrossCutting.Email;
using Infrastructure.CrossCutting.Email.Models;

namespace Presentation.Web.Controllers
{
    public class AccountController : BaseController
    {
        #region Propiedades

        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IFormularioAppService _formularioAppService;

        #endregion

        #region Constructor

        public AccountController(
              IUsuarioAppService usuarioAppService
            , IFormularioAppService formularioAppService)
        {
            _usuarioAppService = usuarioAppService;
            _formularioAppService = formularioAppService;
        }

        #endregion

        #region Acciones

        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LogInDto();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LogInDto model, string returnUrl)
        {
            try
            {
                var usuarioLogueado = _usuarioAppService.ValidateUser(model.UserName, model.Password);

                if (usuarioLogueado == null)
                {
                    ViewBag.MessageError = WebResources.MensajeCredencialesIncorrectas;
                }
                else
                {
                    GenerarTickectAutenticacion(usuarioLogueado);

                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                LogError(ex);

                ViewBag.MessageError = ex.Message;
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            var model = new ForgotPasswordDto();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ActionController(ActionType.Post)]
        public JsonResult ForgotPassword(ForgotPasswordDto model)
        {
            var response = new JsonResponse();
            var usuario = _usuarioAppService.GetByEmail(model.Email);

            if (usuario == null)
            {
                response.Message = ChangePasswordDtoResources.CorreoNoRegistrado;
                Logger.Error(response.Message);
            }
            else
            {
                usuario.Password = Guid.NewGuid().ToString();

                Email.From(ConfigurationAppSettings.EmailPattern())
                    .To(model.Email)
                    .Subject(WebResources.RecuperarContrasenia)
                    .UseSsl()
                    .UsingTemplateFromFile("~/bin/EmailTemplates/ResetPassword.html",
                        new UsuarioModel
                        {
                            UserName = usuario.UserName,
                            Password = usuario.Password,
                            Aplicacion = WebResources.NombreSistema
                        })
                    .Send();

                var respuesta = _usuarioAppService.UpdatePassword(usuario);

                if (respuesta.IsValid)
                {
                    response.Success = respuesta.IsValid;
                    response.Message = WebResources.RegistroSatisfactorio;
                }
                else
                {
                    response.Message = respuesta.ErrorMessage();
                }
            }
            return Json(response);
        }

        [HttpPost]
        [ActionController(ActionType.Post)]
        public JsonResult ChangePassword(ChangePasswordDto model)
        {
            var response = new JsonResponse();
            var usuarioLogueado = _usuarioAppService.ValidateUser(WebSession.Usuario.UserName, model.OldPassword);
            if (usuarioLogueado != null)
            {
                var usuario = new UsuarioDto { Id = usuarioLogueado.Id, Password = model.NewPassword };
                var respuesta = _usuarioAppService.UpdatePassword(usuario);
                if (respuesta.IsValid)
                {
                    response.Success = respuesta.IsValid;
                    response.Message = WebResources.RegistroSatisfactorio;
                }
                else
                {
                    response.Message = respuesta.ErrorMessage();
                }
            }
            else
            {
                response.Message = ChangePasswordDtoResources.ClaveNoCoincide;
            }
            return Json(response);
        }

        public ActionResult LogOut()
        {
            LimpiarAutenticacion();

            return RedirectToAction("Login");
        }

        #endregion

        #region Metodos

        private void GenerarTickectAutenticacion(UsuarioLoginDto usuario)
        {
            usuario.TimeZoneId = ConfigurationAppSettings.TimeZoneId();
            usuario.TimeZoneGMT = ConfigurationAppSettings.TimeZoneGMT();

            AuthenticationHelper.CreateAuthenticationTicket(usuario.UserName, usuario.TimeZoneId);

            WebSession.Usuario = usuario;
            WebSession.Idioma = new IdiomaDto(ConfigurationAppSettings.CultureNameDefault());
            WebSession.Formularios = _formularioAppService.GetByUsuario(usuario.Id);
        }

        private void LimpiarAutenticacion()
        {
            AuthenticationHelper.SignOut();

            WebSession.Usuario = null;
            WebSession.Idioma = null;
            WebSession.Formularios = new List<FormularioDto>();
        }

        #endregion
    }
}