using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Domain.Core.Entities;
using Domain.Core.Interfaces.RepositoryContracts;
using Domain.Core.Pagination;
using Infrastructure.CrossCutting.Enums;
using Infrastructure.Data.Core.Context;
using LinqKit;

namespace Infrastructure.Data.Core.Repository.EntityFramework
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>, IDisposable
        where TEntity : class
    {
        private readonly IDbContext _dbContext;
        private readonly IDbSet<TEntity> _dbSet;

        public Repository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        protected IDbContext Context
        {
            get { return _dbContext; }
        }

        protected IDbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        public virtual TEntity Add(TEntity entity)
        {
            return DbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Attach(entity);

            var entry = Context.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public TEntity Get(TId id)
        {
            return DbSet.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            var entityAuditable = entity as EntityAuditable<TId>;

            if (entityAuditable != null)
            {
                var entryAuditable = Context.Entry(entityAuditable);
                entryAuditable.State = EntityState.Modified;

                entryAuditable.Property(p => p.FechaCreacion).IsModified = false;
                entryAuditable.Property(p => p.UsuarioCreacion).IsModified = false;
            }
            else
            {
                var entry = Context.Entry(entity);
                entry.State = EntityState.Modified;
            }
        }

        public virtual IQueryable<TEntity> All(bool @readonly = true)
        {
            return @readonly
                ? DbSet.AsNoTracking()
                : DbSet;
        }

        public virtual int Count(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.AsExpandable().Where(expression).Count();
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = true)
        {
            return @readonly
                ? DbSet.Where(predicate).AsNoTracking()
                : DbSet.Where(predicate);
        }

        public virtual PaginationResult<TEntity> FindAllPaging(PaginationParameters<TEntity> parameters, bool @readonly = true)
        {
            IQueryable<TEntity> listaAPaginar = (@readonly ? DbSet.AsNoTracking() : DbSet).Where(parameters.WhereFilter);

            listaAPaginar = (parameters.OrderType == TipoOrdenamiento.Ascending)
                ? Queryable.OrderBy(listaAPaginar, (dynamic)parameters.ColumnOrder)
                : Queryable.OrderByDescending(listaAPaginar, (dynamic)parameters.ColumnOrder);

            return new PaginationResult<TEntity>
            {
                Count = listaAPaginar.Count(),
                Entities = listaAPaginar.Skip(parameters.Start).Take(parameters.AmountRows)
            };
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Context == null) return;
            Context.Dispose();
        }

        #endregion
    }
}