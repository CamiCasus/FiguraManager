using Domain.Core.Interfaces.Specifications;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Specifications.UsuarioSpecs
{
    public class EmailLengthMustBeLowerEqualThan100Spec : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return string.IsNullOrEmpty(usuario.Email) || usuario.Email.Trim().Length <= 100;
        }
    }
}