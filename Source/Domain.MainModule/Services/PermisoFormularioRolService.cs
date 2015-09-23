using Domain.Core.Services;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Domain.MainModule.Interfaces.Services;

namespace Domain.MainModule.Services
{
    public class PermisoFormularioRolService : Service<PermisoFormularioRol, int>, IPermisoFormularioRolService
    {
        public PermisoFormularioRolService(IPermisoFormularioRolRepository repository)
            : base(repository)
        { }
    }
}