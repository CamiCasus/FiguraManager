using System.Data.Entity.ModelConfiguration;
using Domain.MainModule.Entities;

namespace Infrastructure.Data.MainModule.Mapping
{
    public class FiguraMap : EntityTypeConfiguration<Figura>
    {
        public FiguraMap()
        {
            Property(p => p.Nombre).IsRequired().HasMaxLength(100);
            Property(p => p.TiendaId).IsRequired();
            Property(p => p.EscultorId).IsRequired();
            Property(p => p.FechaPedido).IsRequired();
            Property(p => p.FechaRelease).IsRequired();
            Property(p => p.EstadoFiguraId).IsRequired();
            Property(p => p.EstadoPedidoId).IsRequired();
            Property(p => p.Precio).IsRequired().HasPrecision(8, 2);
        }
    }
}