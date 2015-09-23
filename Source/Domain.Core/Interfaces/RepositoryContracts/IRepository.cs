using Domain.Core.Pagination;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Core.Interfaces.RepositoryContracts
{
    public interface IRepository<TEntity, in TId> where TEntity : class
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(TId id);
        int Count(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> All(bool @readonly = true);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = true);
        PaginationResult<TEntity> FindAllPaging(PaginationParameters<TEntity> parameters, bool @readonly = true);
    }
}