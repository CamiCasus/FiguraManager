using System;
using System.Globalization;
using System.IO;
using Infrastructure.CrossCutting.Resources;
using Infrastructure.CrossCutting.Resources.Core;

namespace Application.MainModule.DTO.Resources
{
    public class FiguraDtoResources
    {
        private const string Prefix = "FiguraDto";

        private static readonly IResourceProvider ResourceProvider =
            new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Resources\Xml\FiguraDtoResources.xml"));

        public static string NombreRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "NombreRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string NombreDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "NombreDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string TiendaIdRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "TiendaIdRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string TiendaIdDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "TiendaIdDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EscultorIdRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "EscultorIdRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EscultorIdDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "EscultorIdDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string FechaPedidoRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "FechaPedidoRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string FechaPedidoDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "FechaPedidoDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string FechaReleaseRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "FechaReleaseRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string FechaReleaseDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "FechaReleaseDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string FechaLlegadaDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "FechaLlegadaDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string PrecioRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "PrecioRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string PrecioDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "PrecioDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ShippingDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "ShippingDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EstadoFiguraIdDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "EstadoFiguraIdDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EstadoFiguraIdRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "EstadoFiguraIdRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EstadoPedidoIdDisplay
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "EstadoPedidoIdDisplay", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EstadoPedidoIdRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "EstadoPedidoIdRequired", CultureInfo.CurrentUICulture.Name);
            }
        }
    }
}
