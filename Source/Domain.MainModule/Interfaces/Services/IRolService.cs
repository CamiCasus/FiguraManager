using System.Collections.Generic;
using Domain.Core.Interfaces.Services;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Interfaces.Services
{
    public interface IRolService : IReadOnlyService<Rol, int>
    {
        IEnumerable<Rol> GetActivosOrdenadosPorNombreAsc();
    }
}
