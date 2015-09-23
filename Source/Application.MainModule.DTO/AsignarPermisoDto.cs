using System;
using System.Collections.Generic;

namespace Application.MainModule.DTO
{
    [Serializable]
    public class AsignarPermisoDto
    {
        public int FormularioId { get; set; }
        public int RolId { get; set; }
        public int Orden { get; set; }
        public IList<FormularioDto> FormularioList { get; set; }
        public IList<RolDto> RolList { get; set; }
        public IList<PermisoDto> PermisoList { get; set; }
    }
}
