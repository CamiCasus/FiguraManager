using Infrastructure.CrossCutting.Resources;
using Infrastructure.CrossCutting.Resources.Core;
using System;
using System.Globalization;
using System.IO;

namespace Presentation.Web.Resources
{
    public abstract class UsuarioResources
    {
        private const string Prefix = "Usuario";

        private static readonly IResourceProvider ResourceProvider =
            new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Resources\Xml\UsuarioResources.xml"));

        public static string TituloListar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "TituloListar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string TituloCrear
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "TituloCrear", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string TituloEditar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "TituloEditar", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string NoSePuedeEliminar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "NoSePuedeEliminar", CultureInfo.CurrentUICulture.Name);
            }
        }        
    }
}