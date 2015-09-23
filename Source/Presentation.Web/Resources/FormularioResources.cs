using Infrastructure.CrossCutting.Resources;
using Infrastructure.CrossCutting.Resources.Core;
using System;
using System.Globalization;
using System.IO;

namespace Presentation.Web.Resources
{
    public abstract class FormularioResources
    {
        private const string Prefix = "Formulario";

        private static readonly IResourceProvider ResourceProvider =
            new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Resources\Xml\FormularioResources.xml"));

        public static string AsignarPermiso
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "AsignarPermiso", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string OpcionesSistema
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "OpcionesSistema", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Id
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Id", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Formulario
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Formulario", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Permisos
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Permisos", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Rol
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Rol", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Roles
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Roles", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Asignar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Asignar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string SeleccioneFormulario
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "SeleccioneFormulario", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string SeleccioneFormularioNoModulo
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "SeleccioneFormularioNoModulo", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Ver
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Ver", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Mensaje
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Mensaje", CultureInfo.CurrentUICulture.Name);
            }
        }        
    }
}