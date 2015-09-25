using System;
using Application.Core;
using Application.Core.Interfaces;
using Application.MainModule.DTO;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.MainModule.Entities;

namespace Application.MainModule.Interfaces
{
    public interface IFiguraAppService : IAppService<FiguraDto, int>
    {
        //FiguraDto GetFiguraDtoCrear();
        //FiguraDto GetFiguraDtoEditar(int figuraId);

        FiguraIndexDto GetFiguraIndexDto();
        IEnumerable<FiguraDto> GetPedidosRangoFechas(string fechaInicio, string fechaFin);
    }
}
