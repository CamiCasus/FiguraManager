using Domain.Core.Interfaces.Validations;
using Domain.Core.Services;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Domain.MainModule.Interfaces.Services;

namespace Domain.MainModule.Services
{
    public class UsuarioService : Service<Usuario, int>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository, IValidation<Usuario> validation)
            : base(repository, validation)
        {
        }
    }
}