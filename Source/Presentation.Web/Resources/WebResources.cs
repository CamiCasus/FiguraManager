using Infrastructure.CrossCutting.Resources;
using Infrastructure.CrossCutting.Resources.Core;
using System;
using System.Globalization;
using System.IO;

namespace Presentation.Web.Resources
{
    public abstract class WebResources
    {
        private const string Prefix = "Web";

        private static readonly IResourceProvider ResourceProvider =
            new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Resources\Xml\WebResources.xml"));

        public static string NombreSistema
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "NombreSistema", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string DerechoAutor
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "DerechoAutor", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string RecuperarContrasenia
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "RecuperarContrasenia", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string BtnIngresar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "BtnIngresar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string BtnNuevo
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "BtnNuevo", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string BtnEditar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "BtnEditar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string BtnEliminar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "BtnEliminar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string BtnRegresar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "BtnRegresar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string BtnEnviar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "BtnEnviar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string BtnBuscar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "BtnBuscar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string BtnAnular
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "BtnAnular", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string BtnMostrar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "BtnMostrar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string CambiarClave
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "CambiarClave", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string CerrarSesion
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "CerrarSesion", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Panel
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Panel", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ClaveCorrecta
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ClaveCorrecta", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Cerrar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Cerrar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Guardar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Guardar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Cancelar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Cancelar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string RegistroSatisfactorio
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "RegistroSatisfactorio", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ModificacionSatisfactorio
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ModificacionSatisfactorio", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EliminacionSatisfactorio
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "EliminacionSatisfactorio", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string CancelacionSatisfactoria
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "CancelacionSatisfactoria", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string AnulacionSatisfactorio
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "AnulacionSatisfactorio", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ErrorEnRegistro
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ErrorEnRegistro", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Aceptar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Aceptar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string MensajeDeEspera
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "MensajeDeEspera", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Informacion
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Informacion", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Confirmacion
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Confirmacion", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string MensajeDeConfirmacion
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "MensajeDeConfirmacion", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string MensajesDeError
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "MensajesDeError", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string SeleccioneUnRegistro
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "SeleccioneUnRegistro", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string FiltrosDeBusqueda
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "FiltrosDeBusqueda", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Seleccionar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Seleccionar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string MensajeDeMacNoAutorizado
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "MensajeDeMacNoAutorizado", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string HorarioNoPermitido
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "HorarioNoPermitido", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string HorarioMessage
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "HorarioMessage", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ShouldLogIn
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ShouldLogIn", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ServidorSMTP
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ServidorSMTP", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string SeleccioneFecha
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "SeleccioneFecha", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string BtnDescargar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "BtnDescargar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string VerOcultar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "VerOcultar", CultureInfo.CurrentUICulture.Name);
            }
        }
        
        public static string BtnExportar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "BtnExportar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string FechaHora
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "FechaHora", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string BtnImprimir
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "BtnImprimir", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string TituloImpresion
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "TituloImpresion", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ConfirmarImpresion
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ConfirmarImpresion", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ClaveDesembolsoIncorrecta
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ClaveDesembolsoIncorrecta", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string BtnLimpiarCache
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "BtnLimpiarCache", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string MensajeLimpiarCache
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "MensajeLimpiarCache", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Intranet
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Intranet", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string MensajeCredencialesIncorrectas
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "MensajeCredencialesIncorrectas", CultureInfo.CurrentUICulture.Name);
            }
        }  
    }
}