using Domain.Core.Entities;

namespace Domain.MainModule.Entities
{
    public class PermisoFormularioRol : Entity<int>
    {
        public int FormularioId { get; set; }
        public int RolId { get; set; }
        public int TipoPermiso { get; set; }

        public virtual PermisoFormulario PermisoFormulario { get; set; }
        public virtual Rol Rol { get; set; }
    }
}