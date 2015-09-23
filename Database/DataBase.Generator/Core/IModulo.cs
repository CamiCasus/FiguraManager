using System.Data.Entity;

namespace DataBase.Generator.Core
{
    public interface IModulo
    {
        void Registrar(DbContext context);
    }
}