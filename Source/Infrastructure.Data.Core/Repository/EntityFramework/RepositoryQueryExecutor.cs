using System.Collections.Generic;
using Domain.Core.Interfaces.RepositoryContracts;
using Infrastructure.Data.Core.Context;

namespace Infrastructure.Data.Core.Repository.EntityFramework
{
    public class RepositoryQueryExecutor : IRepositoryQueryExecutor
    {
        private readonly IDbContext _dbContext;

        public RepositoryQueryExecutor(IDbContext instanceDbContext)
        {
            _dbContext = instanceDbContext;
        }

        public IEnumerable<TQ> SqlCommand<TQ>(string sql, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<TQ>(sql, parameters);
        }
    }
}