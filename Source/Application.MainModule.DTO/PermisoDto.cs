using System;

namespace Application.MainModule.DTO
{
    [Serializable]
    public class PermisoDto
    {
        public int Tipo { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
