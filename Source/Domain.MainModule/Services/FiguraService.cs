using Domain.Core.Interfaces.Validations;
using Domain.Core.Services;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Domain.MainModule.Interfaces.Services;

namespace Domain.MainModule.Services
{
    public class FiguraService : Service<Figura, int>, IFiguraService
    {
        public FiguraService(IFiguraRepository repository)
            : base(repository)
        {
        }
    }
}