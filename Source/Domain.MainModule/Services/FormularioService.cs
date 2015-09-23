using Domain.Core.Services;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Domain.MainModule.Interfaces.Services;

namespace Domain.MainModule.Services
{
    public class FormularioService : Service<Formulario, int>, IFormularioService
    {
        public FormularioService(IFormularioRepository repository)
            : base(repository)
        { }
    }
}
