using System;
using System.ComponentModel.DataAnnotations;
using Application.MainModule.DTO.Resources;
using Infrastructure.CrossCutting.Resources.Conventions;

namespace Application.MainModule.DTO
{
    [Serializable]
    [MetadataConventions(ResourceType = typeof(FiguraDtoResources))]
    public class FiguraDto
    {
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

        [Required]
        [Display]
        public decimal Precio { get; set; }

        [Display]
        public decimal? Shipping { get; set; }
    }
}