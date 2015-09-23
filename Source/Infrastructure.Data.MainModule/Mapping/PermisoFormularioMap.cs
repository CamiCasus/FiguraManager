using System.Data.Entity.ModelConfiguration;
using Domain.MainModule.Entities;

namespace Infrastructure.Data.MainModule.Mapping
{
    public class PermisoFormularioMap : EntityTypeConfiguration<PermisoFormulario>
    {
        public PermisoFormularioMap()
        {
            HasKey(p => new { p.FormularioId, p.TipoPermiso });
            HasRequired(p => p.Formulario).WithMany(p => p.PermisoList).HasForeignKey(p => p.FormularioId);
        }
    }
}