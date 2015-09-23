using System;
namespace Application.MainModule.DTO
{
    [Serializable]
    public class PermisoFormularioDto
    {
        public int FormularioId { get; set; }
        public int TipoPermiso { get; set; }
        public string NombrePermiso { get; set; }
        public int Estado { get; set; }
        public int Seccion { get; set; }
    }
}
