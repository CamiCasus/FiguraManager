namespace Application.Core.Interfaces
{
    public interface IWriteOnlyAppService<in TEntity>
        where TEntity : class
    {
        ValidationResultDto Create(TEntity entity);
        ValidationResultDto Update(TEntity entity);
        ValidationResultDto Remove(TEntity entity);
    }
}
