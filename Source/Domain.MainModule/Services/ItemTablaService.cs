using Domain.Core.Interfaces.Validations;
using Domain.Core.Services;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Domain.MainModule.Interfaces.Services;

namespace Domain.MainModule.Services
{
    public class ItemTablaService : Service<ItemTabla, int>, IItemTablaService
    {
        public ItemTablaService(IItemTablaRepository repository, IValidation<ItemTabla> validation)
            : base(repository, validation)
        { }
    }
}
