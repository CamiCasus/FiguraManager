using Application.Core;
using System;
using System.Collections.Generic;

namespace Application.MainModule.DTO
{
    [Serializable]
    public class PermisoRolDto : EntityDto<int>
    {
        public PermisoRolDto()
        {
            PermisoList = new List<PermisoDto>();
        }
        public int FormularioId { get; set; }
        public string NombreFormulario { get; set; }
        public string NombreRol { get; set; }
        public int RolId { get; set; }
        public IList<PermisoDto> PermisoList { get; set; }
    }
}
