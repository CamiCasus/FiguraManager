using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Infrastructure.Data.Core.Context;
using Infrastructure.Data.Core.Repository.EntityFramework;

namespace Infrastructure.Data.MainModule
{
    public class RolRepository : Repository<Rol, int>, IRolRepository
    {
        public RolRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
