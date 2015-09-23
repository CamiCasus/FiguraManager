using Infrastructure.CrossCutting.Resources;
using Infrastructure.CrossCutting.Resources.Core;
using System;
using System.Globalization;
using System.IO;

namespace Presentation.Core.Resources
{
    public abstract class PresentationResources
    {
        private const string Prefix = "Presentation";

        private static readonly IResourceProvider ResourceProvider =
            new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Resources\Xml\PresentationResources.xml"));

        public static string DatosIncorrectos
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "DatosIncorrectos", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string RegistroSatisfactorio
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "RegistroSatisfactorio", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string CaracteresInvalidos
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "CaracteresInvalidos", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string NoSePuedeProcesar
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "NoSePuedeProcesar", CultureInfo.CurrentUICulture.Name);
            }
        }
        
    }
}
