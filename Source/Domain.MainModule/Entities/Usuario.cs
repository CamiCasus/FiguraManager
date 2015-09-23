using System.Collections.Generic;
using Domain.Core.Entities;

namespace Domain.MainModule.Entities
{
    public class Usuario : EntityAuditable<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<RolUsuario> RolUsuarioList { get; set; }
        public virtual ICollection<PermisoFormularioUsuario> PermisoUsuarioList { get; set; }
    }
}
