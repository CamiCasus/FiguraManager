using Infrastructure.CrossCutting.Exceptions;
using Infrastructure.CrossCutting.Logging;
using PostSharp.Aspects;
using Presentation.Core;
using Presentation.Core.Resources;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Presentation.Aspects
{
	[Serializable]
	public class PostActionMethod : IActionMethod
	{
		public void Process(MethodInterceptionArgs args, ILogger log)
		{
			var controller = (Controller)args.Instance;

			if (controller.ModelState.IsValid)
			{
				try
				{
					args.Proceed();
				}
                catch (DefaultException ex)
                {
                    log.Error(string.Format("Mensaje: {0} Trace: {1}", ex.Message, ex.StackTrace));

                    var jsonResponse = new JsonResponse { Message = ex.Message };

                    args.ReturnValue = new JsonResult { Data = jsonResponse, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
				catch (Exception ex)
				{
                    string mensajeError = PresentationResources.DatosIncorrectos;

					log.Error(string.Format("Mensaje: {0} Trace: {1}", ex.Message, ex.StackTrace));

                    switch (ex.HResult)
                    {
                        case Constantes.Error2146233087:
                            mensajeError = PresentationResources.NoSePuedeProcesar;
                            break;
                    }

                    var jsonResponse = new JsonResponse { Message = mensajeError };
					args.ReturnValue = new JsonResult { Data = jsonResponse, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
				}
			}
			else
			{
				string message = string.Join("<br />", controller.ModelState.Values.SelectMany(p => p.Errors).Select(p => p.ErrorMessage));

				var jsonResponse = new JsonResponse { Message = message };

				args.ReturnValue = new JsonResult { Data = jsonResponse, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
			}
		}
	}
}