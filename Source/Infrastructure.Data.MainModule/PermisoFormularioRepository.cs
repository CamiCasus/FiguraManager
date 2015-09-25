using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Infrastructure.Data.Core.Context;
using Infrastructure.Data.Core.Repository.EntityFramework;

namespace Infrastructure.Data.MainModule
{
    public class PermisoFormularioRepository : Repository<PermisoFormulario, int>, IPermisoFormularioRepository
    {
        public PermisoFormularioRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
