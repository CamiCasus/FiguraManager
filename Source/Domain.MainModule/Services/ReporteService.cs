using Domain.Core.Interfaces.RepositoryContracts;
using Domain.MainModule.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Domain.MainModule.Services
{
    public class ReporteService<T> : IReporteService<T>
    {
        private readonly IRepositoryQueryExecutor _queryExecutor;

        public ReporteService(IRepositoryQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public List<T> EjecutarQuerySql(string query)
        {
            return _queryExecutor.SqlCommand<T>(query).ToList();
        }
    }
}
