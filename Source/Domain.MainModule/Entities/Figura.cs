using System;
using Domain.Core.Entities;

namespace Domain.MainModule.Entities
{
    public class Figura : Entity<int>
    {
        public string Nombre { get; set; }
        public string Tienda { get; set; }
        public string Escultor { get; set; }
        public DateTime FechaPedido { get; set; }
        public decimal Precio { get; set; }
    }
}
