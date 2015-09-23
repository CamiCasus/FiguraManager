using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Core.Interfaces.Services
{
    public interface IReadOnlyService<TEntity, in TId>
          where TEntity : class
    {
        TEntity Get(TId id);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = true);
    }
}