using System.Data.Entity.ModelConfiguration;
using Domain.MainModule.Entities;

namespace Infrastructure.Data.MainModule.Mapping
{
    public class PermisoFormularioRolMap: EntityTypeConfiguration<PermisoFormularioRol>
    {
        public PermisoFormularioRolMap()
        {
            HasRequired(p => p.PermisoFormulario).WithMany(p => p.PermisoFormularioRolList).HasForeignKey(p => new {p.FormularioId, p.TipoPermiso});
            HasRequired(p => p.Rol).WithMany(p => p.PermisoRolList).HasForeignKey(p => p.RolId);
        }
    }
}