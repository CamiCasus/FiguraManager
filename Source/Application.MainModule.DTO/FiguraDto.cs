using System;

namespace Application.MainModule.DTO
{
    public class FiguraDto
    {
        public string Nombre { get; set; }
        public string Tienda { get; set; }
        public string Escultor { get; set; }
        public string FechaPedido { get; set; }
        public string FechaRelease { get; set; }
        public string FechaLlegada { get; set; }
        public decimal Precio { get; set; } 
    }
}