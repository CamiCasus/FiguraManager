using System;
using Domain.Core.Entities;

namespace Domain.MainModule.Entities
{
    public class Figura : Entity<int>
    {
        public string Nombre { get; set; }
        public int TiendaId { get; set; }
        public int EscultorId { get; set; }
        public int EstadoFiguraId { get; set; }
        public int EstadoPedidoId { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaRelease { get; set; }
        public DateTime? FechaLlegada { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public decimal Precio { get; set; }
        public decimal? Shipping { get; set; }        
    }
}
