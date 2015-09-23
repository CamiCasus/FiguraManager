using Infrastructure.CrossCutting.Enums;
using Presentation.Core;
using System.Web.Mvc;

namespace Presentation.Web.Controllers
{
    public class HomeController : BaseWebController
    {
        [HttpGetAction(TipoPermiso.Ninguno)]
        public ActionResult Index()
        {
            return View();
        }
    }
}