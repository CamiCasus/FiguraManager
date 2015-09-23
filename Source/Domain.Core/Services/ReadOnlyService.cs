using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Core.Interfaces.RepositoryContracts;
using Domain.Core.Interfaces.Services;

namespace Domain.Core.Services
{
    public class ReadOnlyService<TEntity, TId> : IReadOnlyService<TEntity, TId>
         where TEntity : class
    {
        #region Constructor

        private readonly IRepository<TEntity, TId> _repository;

        public ReadOnlyService(IRepository<TEntity, TId> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Properties

        protected IRepository<TEntity, TId> Repository
        {
            get { return _repository; }
        }

        #endregion

        public virtual TEntity Get(TId id)
        {
            return _repository.Get(id);
        }

        public virtual IEnumerable<TEntity> All()
        {
            return _repository.All();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = true)
        {
            return _repository.Find(predicate, @readonly);
        }
    }
}