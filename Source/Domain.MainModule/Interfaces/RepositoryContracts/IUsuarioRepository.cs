using Domain.Core.Interfaces.RepositoryContracts;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Interfaces.RepositoryContracts
{
    public interface IUsuarioRepository : IRepository<Usuario, int>
    {
    }
}
