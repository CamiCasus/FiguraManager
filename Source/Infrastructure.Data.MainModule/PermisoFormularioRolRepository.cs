using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Infrastructure.Data.Core.Context;
using Infrastructure.Data.Core.Repository;
using Infrastructure.Data.Core.Repository.EntityFramework;

namespace Infrastructure.Data.MainModule
{
    public class PermisoFormularioRolRepository : Repository<PermisoFormularioRol, int>, IPermisoFormularioRolRepository
    {
        public PermisoFormularioRolRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
