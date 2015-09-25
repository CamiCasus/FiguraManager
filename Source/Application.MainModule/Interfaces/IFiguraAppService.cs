using Application.Core;
using Application.Core.Interfaces;
using Application.MainModule.DTO;
using System.Collections.Generic;

namespace Application.MainModule.Interfaces
{
    public interface IFiguraAppService : IAppService<FiguraDto, int>
    {
        FiguraDto GetFiguraDtoCrear();
        FiguraDto GetFiguraDtoEditar(int figuraId);
    }
}
