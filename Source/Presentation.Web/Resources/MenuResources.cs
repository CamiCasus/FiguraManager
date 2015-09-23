using Infrastructure.CrossCutting.Resources;
using Infrastructure.CrossCutting.Resources.Core;
using System;
using System.Globalization;
using System.IO;

namespace Presentation.Web.Resources
{
    public abstract class MenuResources
    {
        private const string Prefix = "Menu";

        private static readonly IResourceProvider ResourceProvider =
            new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Resources\Xml\MenuResources.xml"));

        public static string Opciones
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Opciones", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Traduccion(string resourceKey)
        {
            return ResourceProvider.GetResource(Prefix, resourceKey, CultureInfo.CurrentUICulture.Name);
        }
    }
}
