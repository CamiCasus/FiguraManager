using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Application.MainModule.DTO.Resources;
using Infrastructure.CrossCutting.Resources.Conventions;
using Infrastructure.CrossCutting.Common;

namespace Application.MainModule.DTO
{
    [Serializable]
    [MetadataConventions(ResourceType = typeof(FiguraDtoResources))]
    public class FiguraDto
    {
        public int? Id { get; set; }

        [Required]
        [Display]
        public string Nombre { get; set; }

        [Required]
        [Display]
        public int TiendaId { get; set; }

        [Required]
        [Display]
        public int EscultorId { get; set; }

        [Required]
        [Display]
        public int EstadoFiguraId { get; set; }

        [Required]
        [Display]
        public int EstadoPedidoId { get; set; }

        [Required]
        [Display]
        public string FechaPedido { get; set; }

        [Required]
        [Display]
        public string FechaRelease { get; set; }

        [Display]
        public string FechaLlegada { get; set; }

        [Display]
        public string FechaEnvio { get; set; }

        [Required]
        [Display]
        public decimal Precio { get; set; }

        [Display]
        public decimal? Shipping { get; set; }

        [Display]
        public decimal PrecioTotal
        {
            get
            {
                return Precio +( Shipping ?? 0);
            }
        }

        [Display]
        public string PrecioTotalSoles {
            get
            {
                return string.Format("S/. {0:0.00}", (Precio + (Shipping ?? 0)) * ConfigurationAppSettings.ValorTasaConversionYenes()) ;
            }
        }

        public HttpPostedFileBase Imagen { get; set; }

        public string RutaFisicaImagen { get; set; }

        public string RutaImagen { get; set; }
    }
}