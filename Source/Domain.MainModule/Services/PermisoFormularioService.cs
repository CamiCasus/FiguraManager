using Domain.Core.Services;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Domain.MainModule.Interfaces.Services;

namespace Domain.MainModule.Services
{
    public class PermisoFormularioService : Service<PermisoFormulario, int>, IPermisoFormularioService
    {
        public PermisoFormularioService(IPermisoFormularioRepository repository)
            : base(repository)
        { }
    }
}