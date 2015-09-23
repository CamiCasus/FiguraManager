using System.Linq;
using System.Web.Mvc;
using Infrastructure.CrossCutting.Enums;

namespace Presentation.Core.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString PermissionCustomControl(this HtmlHelper htmlHelper, int seccion, TipoPermiso tipoPermiso, string html)
        {
            bool hasPermiso =
                WebSession.FormularioActual.PermisoList.Any(p => p.Seccion == seccion && p.TipoPermiso == (int)tipoPermiso);

            return new MvcHtmlString(hasPermiso ? html : string.Empty);
        }
    }
}