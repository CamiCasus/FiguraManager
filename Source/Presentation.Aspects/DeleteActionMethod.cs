using System;
using System.Web.Mvc;
using Infrastructure.CrossCutting.Logging;
using PostSharp.Aspects;
using Presentation.Core;
using Presentation.Core.Resources;

namespace Presentation.Aspects
{
    [Serializable]
    public class DeleteActionMethod : IActionMethod
    {
        public void Process(MethodInterceptionArgs args, ILogger log)
        {
            try
            {
                args.Proceed();
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
    }
}