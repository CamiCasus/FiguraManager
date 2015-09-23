using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Infrastructure.Data.Core.Context;
using Infrastructure.Data.Core.Repository;
using Infrastructure.Data.Core.Repository.EntityFramework;

namespace Infrastructure.Data.MainModule
{
    public class FormularioRepository : Repository<Formulario, int>, IFormularioRepository
    {
        public FormularioRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
