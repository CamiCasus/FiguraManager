namespace Domain.Core.Interfaces.Specifications
{
    public interface ISpecification<in TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}