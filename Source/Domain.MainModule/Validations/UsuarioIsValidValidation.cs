using Domain.Core.Validations;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Domain.MainModule.Resources;
using Domain.MainModule.Specifications.UsuarioSpecs;

namespace Domain.MainModule.Validations
{
    public class UsuarioIsValidValidation : Validation<Usuario>
    {
        public UsuarioIsValidValidation(IUsuarioRepository usuarioRepository)
        {
            base.AddRule(
                new ValidationRule<Usuario>(new EmailIsRequiredSpec(), UsuarioValidationResources.EmailIsRequired),
                AccionValidar.Create | AccionValidar.Update);
            base.AddRule(
                new ValidationRule<Usuario>(new EmailLengthMustBeLowerEqualThan100Spec(),
                    UsuarioValidationResources.EmailLengthMustBeLowerEqualThan100),
                AccionValidar.Create | AccionValidar.Update);
            base.AddRule(
                new ValidationRule<Usuario>(new PasswordIsRequiredSpec(), UsuarioValidationResources.PasswordIsRequired),
                AccionValidar.Create | AccionValidar.Update);
            base.AddRule(
                new ValidationRule<Usuario>(new PasswordLenghtMustBeLowerEqualThan100Spec(),
                    UsuarioValidationResources.PasswordLenghtMustBeLowerEqualThan100),
                AccionValidar.Create | AccionValidar.Update);
            base.AddRule(
                new ValidationRule<Usuario>(new UserNameIsRequiredSpec(), UsuarioValidationResources.UserNameIsRequired),
                AccionValidar.Create | AccionValidar.Update);
            base.AddRule(
                new ValidationRule<Usuario>(new UserNameLengthMustBeLowerEqualThan100Spec(),
                    UsuarioValidationResources.UserNameLengthMustBeLowerEqualThan100),
                AccionValidar.Create | AccionValidar.Update);
            base.AddRule(new ValidationRule<Usuario>(new UserNameMustBeUniqueSpec(usuarioRepository),
                UsuarioValidationResources.UserNameMustBeUnique), AccionValidar.Create | AccionValidar.Update);
            base.AddRule(new ValidationRule<Usuario>(new EmailMustBeUniqueSpec(usuarioRepository),
                UsuarioValidationResources.EmailMustBeUniqueSpec), AccionValidar.Create | AccionValidar.Update);
        }
    }
}