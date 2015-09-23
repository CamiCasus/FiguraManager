using System.Web.Mvc;

namespace Presentation.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("Error");
        }

        public ActionResult OperationError(string id)
        {
            ViewBag.ErrorMessage = id;
            return View("Error");
        }
    }
}