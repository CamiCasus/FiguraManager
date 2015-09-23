using Domain.Core.Interfaces.Specifications;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Specifications.UsuarioSpecs
{
    public class UserNameLengthMustBeLowerEqualThan100Spec : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return string.IsNullOrEmpty(usuario.UserName) || usuario.UserName.Trim().Length <= 100;
        }
    }
}