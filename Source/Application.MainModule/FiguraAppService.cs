using System;
using System.Collections.Generic;
using System.IO;
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
                _figuraService.Find(
                    p =>
                        p.EstadoPedidoId == (int) TipoPedido.InStock
                            ? (p.FechaPedido >= fechaInicioDate && p.FechaPedido <= fechaFinDate)
                            : (p.FechaEnvio != null
                                ? (p.FechaEnvio >= fechaInicioDate && p.FechaEnvio <= fechaFinDate)
                                : (p.FechaRelease >= fechaInicioDate && p.FechaRelease <= fechaFinDate))).ToList();

            var entityDtoList = MapperHelper.Map<IEnumerable<Figura>, IEnumerable<FiguraDto>>(entityList);

            return entityDtoList;
        }

        [CommitsOperationAspect]
        public ValidationResultDto Create(FiguraDto entityDto)
        {
            var entity = MapperHelper.Map<FiguraDto, Figura>(entityDto);

            if(entityDto.Imagen != null)
            {
                var fileNameArchivo = GenerarArchivo(entityDto);
                entity.Estado = (int)TipoEstado.Activo;
                entity.Imagen = string.Format("~/Figuras/{0}", fileNameArchivo);
            }           

            var validateResult = _figuraService.Add(entity);

            if (!validateResult.IsValid)
                throw new DefaultException(validateResult.ErrorMessage);

            return ValidationResultDto(validateResult);
        }

        [CommitsOperationAspect]
        public ValidationResultDto Update(FiguraDto entityDto)
        {
            var entity = MapperHelper.Map<FiguraDto, Figura>(entityDto);

            if (entityDto.Imagen != null)
            {
                var fileNameArchivo = GenerarArchivo(entityDto);
                entity.Imagen = string.Format("/Figuras/{0}", fileNameArchivo);
            }
            else
                entity.Imagen = entityDto.RutaImagen;           

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

            var listaEstadosFigura =
                _itemTablaService.Find(p => p.TablaId == (int) TipoTabla.EstadoFigura && p.Estado == (int) TipoEstado.Activo);

            var listaEstadosPedido =
                _itemTablaService.Find(
                    p => p.TablaId == (int) TipoTabla.EstadoPedido && p.Estado == (int) TipoEstado.Activo);

            var figuraIndexDto = new FiguraIndexDto
            {
                EstadosPedido = listaEstadosPedido.AsEnumerable()
                    .Select(p => new KeyValuePair<int, string>(int.Parse(p.Valor), p.Nombre)),
                EstadosFigura = listaEstadosFigura.AsEnumerable()
                    .Select(p => new KeyValuePair<int, string>(int.Parse(p.Valor), p.Nombre)),
                Escultores =
                    listaEscultores.AsEnumerable()
                        .Select(p => new KeyValuePair<int, string>(int.Parse(p.Valor), p.Nombre)),
                Tiendas =
                    listaTiendas.AsEnumerable().Select(p => 
                        new DdSlickItem
                        {
                            Text = p.Nombre,
                            Value = p.Valor,
                            ImageSrc = p.Descripcion
                        }),
                Figura = new FiguraDto()
            };

            return figuraIndexDto;
        }

        private string GenerarArchivo(FiguraDto entityDto)
        {
            if (!Directory.Exists(entityDto.RutaFisicaImagen))
                Directory.CreateDirectory(entityDto.RutaFisicaImagen);

            var fileName = string.Format("{0}{1}", entityDto.Id, Path.GetExtension(entityDto.Imagen.FileName));
            var rutaCompletaArchivoImagen = Path.Combine(entityDto.RutaFisicaImagen, fileName);

            if (File.Exists(rutaCompletaArchivoImagen))
                File.Delete(rutaCompletaArchivoImagen);

            entityDto.Imagen.SaveAs(rutaCompletaArchivoImagen);

            return fileName;
        }
    }
}