using System.Collections.Generic;

namespace Domain.Core.Interfaces.RepositoryContracts
{
    public interface IRepositoryQueryExecutor
    {
        IEnumerable<TQ> SqlCommand<TQ>(string sql, params object[] parameters);
    }
}