using System.Data.Entity.ModelConfiguration;
using Domain.MainModule.Entities;

namespace Infrastructure.Data.MainModule.Mapping
{
    public class FormularioMap : EntityTypeConfiguration<Formulario>
    {
        public FormularioMap()
        {
            Property(p => p.Direccion).HasMaxLength(4000);
            Property(p => p.ResourceKey).IsRequired().HasMaxLength(30);

            HasOptional(p => p.FormularioParent).WithMany(p => p.FormulariosHijosList).HasForeignKey(p => p.FormularioParentId);
            Ignore(p => p.ListaFormularios);
        }
    }
}