using Application.MainModule.DTO;
using System.Collections.Generic;

namespace Application.MainModule.Interfaces
{
    public interface IRolAppService 
    {
        IEnumerable<RolDto> GetActivosOrdenadosPorNombre();
    }
}
