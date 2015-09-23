using System.Collections.Generic;

namespace Domain.MainModule.Interfaces.Services
{
    public interface IReporteService<T> 
    {
        List<T> EjecutarQuerySql(string query);
    }
}
