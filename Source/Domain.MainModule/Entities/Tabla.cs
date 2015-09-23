using System.Collections.Generic;
using Domain.Core.Entities;

namespace Domain.MainModule.Entities
{
    public class Tabla : Entity<int>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<ItemTabla> ItemTabla { get; set; }
    }
}