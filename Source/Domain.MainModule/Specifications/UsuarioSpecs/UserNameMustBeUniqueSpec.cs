using Domain.Core.Interfaces.Specifications;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;

namespace Domain.MainModule.Specifications.UsuarioSpecs
{
    public class UserNameMustBeUniqueSpec : ISpecification<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UserNameMustBeUniqueSpec(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool IsSatisfiedBy(Usuario usuario)
        {
            return _usuarioRepository.Count(p => p.UserName == usuario.UserName && p.Id != usuario.Id) == 0;
        }
    }
}