using Infrastructure.CrossCutting.Exceptions;
using Infrastructure.CrossCutting.Logging;
using PostSharp.Aspects;
using System;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Aspects
{
    [Serializable]
    public class GetActionMethod : IActionMethod
    {
        public void Process(MethodInterceptionArgs args, ILogger log)
        {
            try
            {
                args.Proceed();
            }
            catch (DefaultException ex)
            {
                log.Error(string.Format("Mensaje: {0} Trace: {1}", ex.Message, ex.StackTrace));

                var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                var url = urlHelper.Action("OperationError", "Error", new { area = "" });
                url += "/" + ex.Message;
                var result = new RedirectResult(url);
                
                args.ReturnValue = result;
            }
            catch (Exception ex)
            {                
                log.Error(string.Format("Mensaje: {0} Trace: {1}", ex.Message, ex.StackTrace));

                var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                var url = urlHelper.Action("Index", "Error", new { area = "" });

                var result = new RedirectResult(url);

                args.ReturnValue = result;
            }
        }
    }
}
