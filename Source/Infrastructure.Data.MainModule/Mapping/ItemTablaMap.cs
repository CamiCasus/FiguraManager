using System.Data.Entity.ModelConfiguration;
using Domain.MainModule.Entities;

namespace Infrastructure.Data.MainModule.Mapping
{
    public class ItemTablaMap : EntityTypeConfiguration<ItemTabla>
    {
        public ItemTablaMap()
        {
            Property(p => p.Nombre).HasMaxLength(200);
            Property(p => p.Descripcion).HasMaxLength(500);
            Property(p => p.Valor).IsRequired().HasMaxLength(20);

            HasRequired(p => p.Tabla).WithMany(p => p.ItemTabla).HasForeignKey(p => p.TablaId);
        }
    }
}