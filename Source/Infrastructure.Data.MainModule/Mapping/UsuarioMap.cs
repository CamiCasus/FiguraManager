using Domain.MainModule.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Data.MainModule.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            Property(p => p.UserName).IsRequired().HasMaxLength(20);
            Property(p => p.Password).IsRequired().HasMaxLength(100);
            Property(p => p.Email).IsRequired().HasMaxLength(100);
        }
    }
}
