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
using Infrastructure.CrossCutting.Exceptions;
using Infrastructure.Data.Core.UoW;

namespace Application.MainModule
{
    public class FiguraAppService : AppService, IFiguraAppService
    {
        private readonly IFiguraService _figuraService;

        public FiguraAppService(IFiguraService figuraService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _figuraService = figuraService;
        }

        public FiguraDto GetFiguraDtoCrear()
        {
            throw new NotImplementedException();
        }

        public FiguraDto GetFiguraDtoEditar(int figuraId)
        {
            throw new NotImplementedException();
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

        [CommitsOperationAspect]
        public ValidationResultDto Create(FiguraDto entityDto)
        {
            var entity = MapperHelper.Map<FiguraDto, Figura>(entityDto);

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
    }
}