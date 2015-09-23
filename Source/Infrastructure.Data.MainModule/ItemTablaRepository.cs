using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Infrastructure.Data.Core.Context;
using Infrastructure.Data.Core.Repository.EntityFramework;

namespace Infrastructure.Data.MainModule
{
    public class ItemTablaRepository : Repository<ItemTabla, int>, IItemTablaRepository
    {
        public ItemTablaRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
