using Domain.MainModule.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Data.MainModule.Mapping
{
    public class RolMap : EntityTypeConfiguration<Rol>
    {
        public RolMap()
        {
            Property(p => p.Nombre).IsRequired().HasMaxLength(100);
        }
    }
}
