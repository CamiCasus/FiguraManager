using Domain.Core.Interfaces.Specifications;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Specifications.UsuarioSpecs
{
    public class PasswordLenghtMustBeLowerEqualThan100Spec : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return string.IsNullOrEmpty(usuario.Password) || usuario.Password.Trim().Length <= 100;
        }
    }
}