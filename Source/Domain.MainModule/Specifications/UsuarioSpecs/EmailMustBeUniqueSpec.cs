using Domain.Core.Interfaces.Specifications;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;

namespace Domain.MainModule.Specifications.UsuarioSpecs
{
    public class EmailMustBeUniqueSpec : ISpecification<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public EmailMustBeUniqueSpec(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool IsSatisfiedBy(Usuario usuario)
        {
            return _usuarioRepository.Count(p => p.Email == usuario.Email && p.Id != usuario.Id) == 0;
        }
    }
}