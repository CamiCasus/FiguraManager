using System.Data.Entity.ModelConfiguration;
using Domain.MainModule.Entities;

namespace Infrastructure.Data.MainModule.Mapping
{
    public class RolUsuarioMap : EntityTypeConfiguration<RolUsuario>
    {
        public RolUsuarioMap()
        {
            HasKey(p => new { p.UsuarioId, p.RolId });
            HasRequired(p => p.Usuario).WithMany(p => p.RolUsuarioList).HasForeignKey(p => p.UsuarioId).WillCascadeOnDelete(true);
            HasRequired(p => p.Rol).WithMany(p => p.RolUsuarioList).HasForeignKey(p => p.RolId).WillCascadeOnDelete(false);
        }
    }
}