using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.MainModule.Entities;

namespace Infrastructure.Data.MainModule.Mapping
{
    public class TablaMap : EntityTypeConfiguration<Tabla>
    {
        public TablaMap()
        {
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Nombre).IsRequired().HasMaxLength(40);
            Property(p => p.Descripcion).HasMaxLength(250);
        }
    }
}