using Infrastructure.CrossCutting.Resources;
using Infrastructure.CrossCutting.Resources.Core;
using System;
using System.Globalization;
using System.IO;

namespace Application.MainModule.DTO.Resources
{
    public abstract class ChangePasswordDtoResources
    {
        private const string Prefix = "ChangePasswordDto";

        private static readonly IResourceProvider ResourceProvider =
            new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Resources\Xml\ChangePasswordDtoResources.xml"));

        public static string ClaveActual
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ClaveActual", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ClaveActualRequerido
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ClaveActualRequerido", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ClaveNueva
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ClaveNueva", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ClaveNuevaRequerido
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ClaveNuevaRequerido", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ConfirmarClaveNueva
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ConfirmarClaveNueva", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ConfirmarClaveNuevaRequerido
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ConfirmarClaveNuevaRequerido", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Coincidencia
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Coincidencia", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ClaveLongitud
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ClaveLongitud", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ClaveCoincidencia
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ClaveCoincidencia", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ClaveLongitudMinimun
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ClaveLongitudMinimun", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ConfirmacionClaveLongitudMinimun
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ConfirmacionClaveLongitudMinimun", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ClaveNoCoincide
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ClaveNoCoincide", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string CorreoNoRegistrado
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "CorreoNoRegistrado", CultureInfo.CurrentUICulture.Name);
            }
        }
        
        
    }
}
