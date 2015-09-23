using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Core.Interfaces
{
    public interface IReadOnlyAppService<TEntity, in TId> where TEntity : class
    {
        TEntity Get(TId id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = true);
    }
}
