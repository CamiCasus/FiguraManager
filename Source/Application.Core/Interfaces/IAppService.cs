namespace Application.Core.Interfaces
{
    public interface IAppService<TEntity, in TId>
        : IReadOnlyAppService<TEntity, TId>
        , IWriteOnlyAppService<TEntity>
        where TEntity : class
    {
    }
}
