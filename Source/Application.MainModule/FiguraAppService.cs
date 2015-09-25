using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Aspects;
using Application.Core.Extensions;
using Application.Core;
using Application.MainModule.DTO;
using Application.MainModule.Interfaces;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.Services;
using Infrastructure.CrossCutting.Enums;
using Infrastructure.CrossCutting.Exceptions;
using Infrastructure.Data.Core.UoW;

namespace Application.MainModule
{
    public class FiguraAppService : AppService, IFiguraAppService
    {
        private readonly IItemTablaService _itemTablaService;
        private readonly IFiguraService _figuraService;

        public FiguraAppService(IFiguraService figuraService, IItemTablaService itemTablaService, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _figuraService = figuraService;
            _itemTablaService = itemTablaService;
        }

        public FiguraDto Get(int id)
        {
            var entity = _figuraService.Get(id);
            var entityDto = MapperHelper.Map<Figura, FiguraDto>(entity);

            return entityDto;
        }

        public IEnumerable<FiguraDto> Find(Expression<Func<FiguraDto, bool>> predicateDto, bool @readonly = true)
        {
            var predicate = predicateDto.CreateDtoToEntityExpression<Figura, FiguraDto>();

            var entityList = _figuraService.Find(predicate, @readonly).ToList();
            var entityDtoList = MapperHelper.Map<IEnumerable<Figura>, IEnumerable<FiguraDto>>(entityList);

            return entityDtoList;
        }

        public IEnumerable<FiguraDto> GetPedidosRangoFechas(string fechaInicio, string fechaFin)
        {
            var fechaInicioDate = DateTime.Parse(fechaInicio);
            var fechaFinDate = DateTime.Parse(fechaFin);

            var entityList =
                _figuraService.Find(p => p.FechaRelease >= fechaInicioDate && p.FechaRelease <= fechaFinDate).ToList();

            var entityDtoList = MapperHelper.Map<IEnumerable<Figura>, IEnumerable<FiguraDto>>(entityList);

            return entityDtoList;
        }

        [CommitsOperationAspect]
        public ValidationResultDto Create(FiguraDto entityDto)
        {
            var entity = MapperHelper.Map<FiguraDto, Figura>(entityDto);
            entity.Estado = (int) TipoEstado.Activo;

            var validateResult = _figuraService.Add(entity);

            if (!validateResult.IsValid)
                throw new DefaultException(validateResult.ErrorMessage);

            return ValidationResultDto(validateResult);
        }

        [CommitsOperationAspect]
        public ValidationResultDto Update(FiguraDto entityDto)
        {
            var entity = MapperHelper.Map<FiguraDto, Figura>(entityDto);
            var validateResult = _figuraService.Update(entity);

            if (!validateResult.IsValid)
                throw new DefaultException(validateResult.ErrorMessage);

            return ValidationResultDto(validateResult);
        }

        [CommitsOperationAspect]
        public ValidationResultDto Remove(FiguraDto entityDto)
        {
            var entity = MapperHelper.Map<FiguraDto, Figura>(entityDto);
            var validateResult = _figuraService.Delete(entity);

            if (!validateResult.IsValid)
                throw new DefaultException(validateResult.ErrorMessage);

            return ValidationResultDto(validateResult);
        }

        public FiguraIndexDto GetFiguraIndexDto()
        {
            var listaEscultores =
                _itemTablaService.Find(p => p.TablaId == (int) TipoTabla.Escultor && p.Estado == (int) TipoEstado.Activo);

            var listaTiendas =
                _itemTablaService.Find(p => p.TablaId == (int)TipoTabla.Tienda && p.Estado == (int)TipoEstado.Activo);

            var figuraIndexDto = new FiguraIndexDto
            {
                Escultores =
                    listaEscultores.AsEnumerable()
                        .Select(p => new KeyValuePair<int, string>(int.Parse(p.Valor), p.Nombre)),
                Tiendas =
                    listaTiendas.AsEnumerable().Select(p => new KeyValuePair<int, string>(int.Parse(p.Valor), p.Nombre)),
                Figura = new FiguraDto()
            };

            return figuraIndexDto;
        }
    }
}