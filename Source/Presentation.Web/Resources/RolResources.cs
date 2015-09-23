using Infrastructure.CrossCutting.Resources;
using Infrastructure.CrossCutting.Resources.Core;
using System;
using System.Globalization;
using System.IO;

namespace Presentation.Web.Resources
{
    public abstract class RolResources
    {
        private const string Prefix = "Rol";

        private static readonly IResourceProvider ResourceProvider =
            new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Resources\Xml\RolResources.xml"));

        public static string Id
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Id", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Rol
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Rol", CultureInfo.CurrentUICulture.Name);
            }
        }
    }
}