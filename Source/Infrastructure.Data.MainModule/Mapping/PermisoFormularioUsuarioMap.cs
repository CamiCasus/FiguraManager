using System.Data.Entity.ModelConfiguration;
using Domain.MainModule.Entities;

namespace Infrastructure.Data.MainModule.Mapping
{
    public class PermisoFormularioUsuarioMap: EntityTypeConfiguration<PermisoFormularioUsuario>
    {
        public PermisoFormularioUsuarioMap()
        {
            HasRequired(p => p.PermisoFormulario).WithMany().HasForeignKey(p => new {p.FormularioId, p.TipoPermiso});
            HasRequired(p => p.Usuario).WithMany(p => p.PermisoUsuarioList).HasForeignKey(p => p.UsuarioId);
        }
    }
}