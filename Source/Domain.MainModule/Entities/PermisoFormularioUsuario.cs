using Domain.Core.Entities;

namespace Domain.MainModule.Entities
{
    public class PermisoFormularioUsuario : Entity<int>
    {
        public int FormularioId { get; set; }
        public int UsuarioId { get; set; }
        public int TipoPermiso { get; set; }

        public virtual PermisoFormulario PermisoFormulario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}