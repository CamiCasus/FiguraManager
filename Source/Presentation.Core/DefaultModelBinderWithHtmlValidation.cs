using Infrastructure.CrossCutting.Logging;
using Presentation.Core.Resources;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Core
{
    public class DefaultModelBinderWithHtmlValidation : DefaultModelBinder
    {
        protected static readonly ILogger Logger = new Log4Net();

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                return base.BindModel(controllerContext, bindingContext);
            }
            catch (HttpRequestValidationException)
            {
                var mensaje = string.Format(PresentationResources.CaracteresInvalidos, bindingContext.ModelMetadata.DisplayName ?? bindingContext.ModelName);

                Logger.Error(mensaje);

                bindingContext.ModelState.AddModelError(bindingContext.ModelName, mensaje);
            }

            var provider = bindingContext.ValueProvider as IUnvalidatedValueProvider;
            if (provider == null) return null;

            var result = provider.GetValue(bindingContext.ModelName, true);
            return result.AttemptedValue;
        }
    }
}
