using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Aspects;
using Application.Core;
using Application.Core.Extensions;
using Application.MainModule.DTO;
using Application.MainModule.DTO.Resources;
using Application.MainModule.Interfaces;
using Domain.Core.Interfaces.OrderBy;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.Services;
using Infrastructure.CrossCutting.Common;
using Infrastructure.CrossCutting.Enums;
using Infrastructure.CrossCutting.Exceptions;
using Infrastructure.Data.Core.UoW;

namespace Application.MainModule
{
    public class UsuarioAppService : AppService, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IOrderByEntity<Usuario> _usuarioOrderByEntity;
        private readonly IReporteService<UsuarioDto> _reporteService;
        private readonly IRolAppService _rolAppService;
        private readonly IItemTablaService _itemTablaService;

        public UsuarioAppService(
            IUsuarioService usuarioService
            , IUnitOfWork unitOfWork
            , IReporteService<UsuarioDto> reporteService
            , IRolAppService rolAppService
            , IItemTablaService itemTablaService
            , IOrderByEntity<Usuario> usuarioOrderByEntity)
            : base(unitOfWork)
        {
            _usuarioService = usuarioService;
            _usuarioOrderByEntity = usuarioOrderByEntity;
            _reporteService = reporteService;
            _itemTablaService = itemTablaService;
            _rolAppService = rolAppService;
        }

        #region Metodos Publicos

        public UsuarioLoginDto ValidateUser(string username, string password)
        {
            var claveEncriptada = Encriptador.Encriptar(password);

            var entity = _usuarioService.Find(p => p.UserName == username && p.Password == claveEncriptada);

            if (!entity.Any())
                throw new Exception(UsuarioDtoResources.CredencialesIncorrectas);

            var usuarioEntity = entity.FirstOrDefault(p => p.Estado == (int)TipoEstado.Activo);
            if (usuarioEntity == null)
                throw new Exception(UsuarioDtoResources.UsuarioInactivo);

            var entityDto = MapperHelper.Map<Usuario, UsuarioLoginDto>(usuarioEntity);
            return entityDto;
        }

        public UsuarioDto GetUsuarioDtoCrear()
        {
            var estadosDisponibles = ObtenerEstados();

            var usuarioDto = new UsuarioDto
            {
                Estados = estadosDisponibles,
                RolDtos = _rolAppService.GetActivosOrdenadosPorNombre(),
                Accion = MasterConstantes.AccionCrear,
                Estado = (int) TipoEstado.Activo,
            };

            return usuarioDto;
        }

        public UsuarioDto GetUsuarioDtoEditar(int usuarioId)
        {
            var usuarioDto = Get(usuarioId);
            var estadosDisponibles = ObtenerEstados();

            usuarioDto.Accion = MasterConstantes.AccionEditar;
            usuarioDto.RolDtos = _rolAppService.GetActivosOrdenadosPorNombre();
            usuarioDto.Estados = estadosDisponibles;

            return usuarioDto;
        }

        public UsuarioDto GetByEmail(string email)
        {
            var entity = _usuarioService.Find(p => p.Email == email);

            if (!entity.Any()) return null;

            var entityDto = MapperHelper.Map<Usuario, UsuarioDto>(entity.FirstOrDefault());
            return entityDto;
        }

        #endregion

        #region Metodos de Búsqueda

        public UsuarioDto Get(int id)
        {
            var entity = _usuarioService.Get(id);
            var entityDto = MapperHelper.Map<Usuario, UsuarioDto>(entity);

            return entityDto;
        }

        public IEnumerable<UsuarioDto> Find(Expression<Func<UsuarioDto, bool>> predicateDto, bool @readonly = true)
        {
            var predicate = predicateDto.CreateDtoToEntityExpression<Usuario, UsuarioDto>();

            var entityList = _usuarioService.Find(predicate, @readonly).ToList();
            var entityDtoList = MapperHelper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioDto>>(entityList);

            return entityDtoList;
        }

        public PaginationResultDto<UsuarioPaginationDto> FindAllPaging(PaginationParametersDto<UsuarioPaginationDto> parameters, bool @readonly = true)
        {
            var nuevoParameters = DomainFilterFactory.GenerateDomainFilterParameters(parameters, _usuarioOrderByEntity);
            var pagingResult = _usuarioService.FindAllPaging(nuevoParameters, @readonly);
            var entityDtoList = MapperHelper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioPaginationDto>>(pagingResult.Entities);

            return new PaginationResultDto<UsuarioPaginationDto> { Count = pagingResult.Count, Entities = entityDtoList };
        }

        #endregion

        #region Métodos de Operaciones

        [CommitsOperationAspect]
        public ValidationResultDto Create(UsuarioDto entityDto)
        {
            var entity = MapperHelper.Map<UsuarioDto, Usuario>(entityDto);

            if (entity.RolUsuarioList == null)
                entity.RolUsuarioList = new List<RolUsuario>();
            else
                entity.RolUsuarioList.Clear();

            entity.RolUsuarioList.Add(MapperHelper.Map<UsuarioDto, RolUsuario>(entityDto));

            var validateResult = _usuarioService.Add(entity);

            if (!validateResult.IsValid)
                throw new DefaultException(validateResult.ErrorMessage);

            return ValidationResultDto(validateResult);
        }

        [CommitsOperationAspect]
        public ValidationResultDto Update(UsuarioDto entityDto)
        {
            var usuarioDomain = _usuarioService.Get(entityDto.Id);
            usuarioDomain = MapperHelper.Map(entityDto, usuarioDomain);

            usuarioDomain.RolUsuarioList.Clear();
            usuarioDomain.RolUsuarioList.Add(MapperHelper.Map<UsuarioDto, RolUsuario>(entityDto));

            var validateResult = _usuarioService.Update(usuarioDomain);

            if (!validateResult.IsValid)
                throw new DefaultException(validateResult.ErrorMessage);

            return ValidationResultDto(validateResult);
        }

        [CommitsOperationAspect]
        public ValidationResultDto UpdatePassword(UsuarioDto entityDto)
        {
            var usuarioDomain = _usuarioService.Get(entityDto.Id);
            usuarioDomain.Password = Encriptador.Encriptar(entityDto.Password);
            var validateResult = _usuarioService.Update(usuarioDomain);

            if (!validateResult.IsValid)
                throw new DefaultException(validateResult.ErrorMessage);

            return ValidationResultDto(validateResult);
        }

        [CommitsOperationAspect]
        public ValidationResultDto Remove(UsuarioDto entityDto)
        {
            var entity = MapperHelper.Map<UsuarioDto, Usuario>(entityDto);
            var validateResult = _usuarioService.Delete(entity);

            if (!validateResult.IsValid)
                throw new DefaultException(validateResult.ErrorMessage);

            return ValidationResultDto(validateResult);
        }

        #endregion

        #region Métodos privados
      
        private IEnumerable<KeyValuePair<string, string>> ObtenerEstados()
        {
            return
                _itemTablaService.Find(
                    p => p.Estado == (int) TipoEstado.Activo && p.TablaId == (int) TipoTabla.TipoEstado)
                    .AsEnumerable()
                    .Select(p => new KeyValuePair<string, string>(p.Valor, p.Nombre));
        }

        #endregion

        #region Métodos de Reporte

        public IEnumerable<UsuarioDto> GetUsuarioReport(UsuarioDto model)
        {
            const string storeName = "GetUsuarioReport";
            var query = string.Format("{0} @RolId = {1}, @UserName = '{2}', @FechaDesde = '{3}', @FechaHasta = '{4}'",
                storeName, model.RolId, model.UserName, "10-06-2015","");

            var entityList = _reporteService.EjecutarQuerySql(query);

            return entityList;
        }

        #endregion
    }
}

