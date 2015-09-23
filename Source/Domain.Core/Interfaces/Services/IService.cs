using Domain.Core.Pagination;
using Domain.Core.Validations;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Core.Interfaces.Services
{
    public interface IService<TEntity, in TId>
        where TEntity : class
    {
        TEntity Get(TId id);
        IQueryable<TEntity> All(bool @readonly = false);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = true);
        PaginationResult<TEntity> FindAllPaging(PaginationParameters<TEntity> parameters, bool @readonly = true);
        ValidationResultWithType<TEntity> Add(TEntity entityDto);
        ValidationResult Update(TEntity entityDto);
        ValidationResult Delete(TEntity entityDto);
    }
}