using System.Collections.Generic;
using Domain.Core.Entities;

namespace Domain.MainModule.Entities
{
    public class PermisoFormulario : EntityBase
    {
        public int FormularioId { get; set; }
        public int TipoPermiso { get; set; }
        public int Seccion { get; set; }

        public virtual Formulario Formulario { get; set; }
        public virtual ICollection<PermisoFormularioRol> PermisoFormularioRolList { get; set; }
    }
}