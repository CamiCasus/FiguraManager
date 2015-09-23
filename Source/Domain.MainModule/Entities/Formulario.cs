using System.Collections.Generic;
using Domain.Core.Entities;

namespace Domain.MainModule.Entities
{
    public class Formulario : Entity<int>
    {
        public string ResourceKey { get; set; }
        public string Direccion { get; set; }
        public string Icono { get; set; }
        public int Orden { get; set; }
        public int? FormularioParentId { get; set; }

        public virtual Formulario FormularioParent { get; set; }

        public virtual ICollection<PermisoFormulario> PermisoList { get; set; }
        public virtual ICollection<Formulario> FormulariosHijosList { get; set; }
        public virtual ICollection<Formulario> ListaFormularios { get; set; }
    }
}