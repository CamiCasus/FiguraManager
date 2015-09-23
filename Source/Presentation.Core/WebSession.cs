using Application.MainModule.DTO;
using System.Collections.Generic;
using System.Web;

namespace Presentation.Core
{
    public static class WebSession
    {
        public static UsuarioLoginDto Usuario
        {
            get { return HttpContext.Current.Session[Constantes.UsuarioSesion] as UsuarioLoginDto; }
            set { HttpContext.Current.Session.Add(Constantes.UsuarioSesion, value); }
        }

        public static IdiomaDto Idioma
        {
            get { return HttpContext.Current.Session[Constantes.IdiomaSesion] as IdiomaDto; }
            set { HttpContext.Current.Session.Add(Constantes.IdiomaSesion, value); }
        }

        public static IEnumerable<FormularioDto> Formularios
        {
            get { return HttpContext.Current.Session[Constantes.FormulariosSesion] as IEnumerable<FormularioDto>; }
            set { HttpContext.Current.Session.Add(Constantes.FormulariosSesion, value); }
        }

        public static FormularioDto FormularioActual
        {
            get { return HttpContext.Current.Session[Constantes.FormularioActualSesion] as FormularioDto; }
            set { HttpContext.Current.Session.Add(Constantes.FormularioActualSesion, value); }
        }
    }
}
