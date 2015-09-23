using Domain.Core.Interfaces.RepositoryContracts;
using Domain.Core.Interfaces.Services;
using Domain.Core.Interfaces.Validations;
using Domain.Core.Pagination;
using Domain.Core.Validations;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Core.Services
{
    public class Service<TEntity, TId> : IService<TEntity, TId>
        where TEntity : class
    {
        #region Variables

        private readonly IRepository<TEntity, TId> _repository;
        private readonly IValidation<TEntity> _validation;

        #endregion

        #region Constructor

        public Service(IRepository<TEntity, TId> repository)
            : this(repository, null)
        {
        }

        public Service(IRepository<TEntity, TId> repository, IValidation<TEntity> validation)
        {
            _repository = repository;
            _validation = validation;
        }

        #endregion

        #region Properties

        protected IRepository<TEntity, TId> Repository
        {
            get { return _repository; }
        }

        #endregion

        #region Read Methods

        public virtual TEntity Get(TId id)
        {
            return _repository.Get(id);
        }

        public virtual IQueryable<TEntity> All(bool @readonly = true)
        {
            return _repository.All(@readonly);
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = true)
        {
            return _repository.Find(predicate, @readonly);
        }

        public virtual PaginationResult<TEntity> FindAllPaging(PaginationParameters<TEntity> parameters, bool @readonly = true)
        {
            return _repository.FindAllPaging(parameters, @readonly);
        }

        #endregion

        #region CRUD Methods

        public virtual ValidationResultWithType<TEntity> Add(TEntity entity)
        {
            var validationResult = new ValidationResultWithType<TEntity>();

            var validateEntityResult = ValidateEntity(entity, AccionValidar.Update);

            if (validateEntityResult.IsValid)
            {
                validationResult.Data = _repository.Add(entity);
            }
            else
            {
                validationResult.Add(validateEntityResult);
            }

            return validationResult;
        }

        public virtual ValidationResult Update(TEntity entity)
        {
            var validateEntityResult = ValidateEntity(entity, AccionValidar.Update);

            if (validateEntityResult.IsValid)
            {
                _repository.Update(entity);
            }

            return validateEntityResult;
        }

        public virtual ValidationResult Delete(TEntity entity)
        {
            var validateEntityResult = ValidateEntity(entity, AccionValidar.Delete);

            if (validateEntityResult.IsValid)
            {
                _repository.Delete(entity);
            }

            return validateEntityResult;
        }

        private ValidationResult ValidateEntity(TEntity entity, AccionValidar accion)
        {
            if (_validation != null)
            {
                var validationResultEntity = _validation.Valid(entity, accion);

                return validationResultEntity;
            }
            return new ValidationResult();
        }

        #endregion
    }
}