using Domain.Core.Entities;

namespace Domain.MainModule.Entities
{
    public class RolUsuario : EntityBase
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Rol Rol { get; set; }
    }
}