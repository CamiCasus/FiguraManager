using System.Collections.Generic;
using System.Linq;
using Domain.Core.Services;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Domain.MainModule.Interfaces.Services;
using Infrastructure.CrossCutting.Enums;

namespace Domain.MainModule.Services
{
    public class RolService : ReadOnlyService<Rol, int>, IRolService
    {
        private readonly IRolRepository _rolRepository;

        public RolService(IRolRepository repository)
            : base(repository)
        {
            _rolRepository = repository;
        }

        public IEnumerable<Rol> GetActivosOrdenadosPorNombreAsc()
        {
            return _rolRepository.Find(p => p.Estado == (int) TipoEstado.Activo).OrderBy(p => p.Nombre);
        }
    }
}
