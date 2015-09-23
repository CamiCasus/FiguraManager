using Domain.Core.Validations;

namespace Domain.Core.Interfaces.Validations
{
    public interface IValidation<TEntity>
    {
        ValidationResult Valid(TEntity entity, AccionValidar accionValidar);
    }
}