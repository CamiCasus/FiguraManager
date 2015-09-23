using Domain.Core.Validations;

namespace Domain.Core.Interfaces.Validations
{
    public interface ISelfValidation<TEntity>
    {
        ValidationResultWithType<TEntity> ValidationResult { get; }
        bool IsValid { get; }
    }
}