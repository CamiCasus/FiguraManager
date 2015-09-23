using System;
using System.Globalization;
using System.IO;
using Infrastructure.CrossCutting.Resources;
using Infrastructure.CrossCutting.Resources.Core;

namespace Application.MainModule.DTO.Resources
{
    public class UsuarioDtoResources
    {
        private const string Prefix = "UsuarioDto";

        private static readonly IResourceProvider ResourceProvider =
            new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Resources\Xml\UsuarioDtoResources.xml"));

        public static string UserNameRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "UserNameRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string UserNameStringLength
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "UserNameStringLength", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string UserNameDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "UserNameDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EmailRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "EmailRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EmailStringLength
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "EmailStringLength", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EmailDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "EmailDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string OperadorTelefonicoDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "OperadorTelefonicoDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string OperadorTelefonicoRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "OperadorTelefonicoRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string TelefonoRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "TelefonoRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string TelefonoStringLength
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "TelefonoStringLength", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string TelefonoDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "TelefonoDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string RolIdRange
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "RolIdRange", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string RolIdDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "RolIdDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string AgenciaIdRange
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "AgenciaIdRange", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string AgenciaIdDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "AgenciaIdDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string NombresRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "NombresRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string NombresStringLength
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "NombresStringLength", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string NombresDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "NombresDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ApellidosRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ApellidosRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ApellidosStringLength
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ApellidosStringLength", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ApellidosDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ApellidosDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string TipoDocumentoRange
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "TipoDocumentoRange", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string TipoDocumentoDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "TipoDocumentoDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string NumeroDocumentoRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "NumeroDocumentoRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string NumeroDocumentoStringLength
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "NumeroDocumentoStringLength", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string NumeroDocumentoDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "NumeroDocumentoDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string DireccionStringLength
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "DireccionStringLength", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string DireccionDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "DireccionDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EstadoDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "EstadoDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string CredencialesIncorrectas
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "CredencialesIncorrectas", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string UsuarioInactivo
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "UsuarioInactivo", CultureInfo.CurrentUICulture.Name);
            }
        }        
    }
}