using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Application.MainModule.DTO.AutoMapper;
using Infrastructure.CrossCutting.Common;
using Infrastructure.CrossCutting.Logging;
using Infrastructure.CrossCutting.Resources.Conventions;
using Infrastructure.Data.Core;
using Presentation.Core;

namespace Presentation.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            PersistenceConfigurator.Configure("SIGCOMT");

            Log4NetConfigurator.Configure();

            AutoMapperConfiguration.Configure();

            //ModelMetadataProviders.Current = new ConventionalModelMetadataProvider(true, typeof(WebResources));

            ModelBinders.Binders.DefaultBinder = new DefaultModelBinderWithHtmlValidation();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Session.Timeout = ConfigurationAppSettings.TimeOutSession();
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            //HttpContext context = HttpContext.Current;

            //if (context != null && context.Session != null)
            //{
            //    var codigoIdioma = ConfigurationAppSettings.CultureNameDefault();

            //    if (WebSession.Idioma != null) codigoIdioma = WebSession.Idioma.Codigo;

            //    Thread.CurrentThread.CurrentCulture = new CultureInfo(codigoIdioma);
            //    Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            //}
        }
    }
}
