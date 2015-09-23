using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Infrastructure.Data.Core.Context
{
    public interface IDbContext
    {
        Database Database { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
        void Dispose();
    }
}
