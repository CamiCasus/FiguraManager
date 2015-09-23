using System.Reflection;
using System.Web.Mvc;

namespace Presentation.Core.HtmlHelpers
{
    public static class FileAutoVersioningHelper
    {
        private readonly static string _version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static string GeneratePath(string fileName)
        {
            return string.Format("{0}?v={1}", fileName, _version);
        }
    }

    public static class UrlHelperExtensions
    {
        public static string Stylesheet(this UrlHelper helper, string fileName)
        {
            return helper.Content(string.Format("{0}", FileAutoVersioningHelper.GeneratePath(fileName)));
        }

        public static string Script(this UrlHelper helper, string fileName)
        {
            return helper.Content(string.Format("{0}", FileAutoVersioningHelper.GeneratePath(fileName)));
        }
    }
}
