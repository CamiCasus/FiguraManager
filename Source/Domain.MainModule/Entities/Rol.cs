using Domain.Core.Entities;
using System.Collections.Generic;

namespace Domain.MainModule.Entities
{
    public class Rol : Entity<int>
    {
        public string Nombre { get; set; }

        public virtual ICollection<RolUsuario> RolUsuarioList { get; set; }
        public virtual ICollection<PermisoFormularioRol> PermisoRolList { get; set; }
    }
}
