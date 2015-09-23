using Application.Aspects;
using Application.Core;
using Application.MainModule.DTO;
using Application.MainModule.Interfaces;
using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.Services;
using Infrastructure.CrossCutting.Enums;
using Infrastructure.Data.Core.UoW;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.MainModule
{
    public class FormularioAppService : AppService, IFormularioAppService
    {
        #region Members

        private readonly IUsuarioService _usuarioService;
        private readonly IFormularioService _formularioService;
        private readonly IRolService _rolService;
        private readonly IPermisoFormularioRolService _permisoRolService;
        private readonly IItemTablaService _itemTablaService;
 
        #endregion

        #region Constructor
        public FormularioAppService(
            IUsuarioService usuarioService,
            IFormularioService formularioService,
            IRolService rolService,
            IPermisoFormularioRolService permisoRolService,
            IItemTablaService itemTablaService,
            IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _usuarioService = usuarioService;
            _formularioService = formularioService;
            _rolService = rolService;
            _permisoRolService = permisoRolService;
            _itemTablaService = itemTablaService;
        } 

        #endregion

        #region Métodos Públicos
        public IEnumerable<FormularioDto> GetByUsuario(int idUsuario)
        {
            const int estadoActivo = (int)TipoEstado.Activo;
            const int permisoMostrar = (int)TipoPermiso.Mostrar;
            var usuario = _usuarioService.Get(idUsuario);

            var listaRolesUsuario = usuario.RolUsuarioList.Where(p => p.Estado == estadoActivo).Select(p => p.RolId).ToList();
            var listaPermisosRolUsuario =
                _permisoRolService.Find(
                    p =>
                        listaRolesUsuario.Contains(p.RolId) &&
                        p.Estado == estadoActivo &&
                        p.PermisoFormulario.Estado == estadoActivo
                        , false)
                    .Select(p => p.PermisoFormulario)
                    .ToList();

            var formularios =
                listaPermisosRolUsuario.Where(
                    p => p.TipoPermiso == permisoMostrar &&
                         p.Formulario.FormularioParentId == null)
                    .Select(p => p.Formulario)
                    .ToList();

            var formulariosDto = MapperHelper.Map<List<Formulario>, List<FormularioDto>>(formularios);
            var permisosDto = MapperHelper.Map<List<PermisoFormulario>, List<PermisoFormularioDto>>(listaPermisosRolUsuario);

            formulariosDto = AsignarPermisosFormularios(formulariosDto, permisosDto);

            return formulariosDto;
        }

        public IEnumerable<FormularioDto> All()
        {
            const int estadoActivo = (int)TipoEstado.Activo;

            var entityList = _formularioService.Find(p => p.Estado == estadoActivo);
            var entityDtoList = MapperHelper.Map<IEnumerable<Formulario>, IEnumerable<FormularioDto>>(entityList);

            return entityDtoList;
        }

        public IList<FormularioDto> AllToTree()
        {
            const int estadoActivo = (int)TipoEstado.Activo;

            var modulos = _formularioService.Find(p => p.FormularioParent == null && p.Estado == estadoActivo).ToList();
            return GenerateTreeView(modulos);
        }

        public PermisoRolDto ObtenerPermisos(PermisoRolDto model)
        {
            const int estadoActivo = (int)TipoEstado.Activo;

            var rol = _rolService.Get(model.RolId);
            var formulario = _formularioService.Get(model.FormularioId);
            var permisos = rol.PermisoRolList.Where(p => p.Estado == estadoActivo && p.FormularioId == model.FormularioId).ToList();
            var listaItemTabla = _itemTablaService.Find(p => p.TablaId == (int)TipoTabla.TipoPermiso && p.Estado == (int)TipoEstado.Activo).ToList();

            model.NombreFormulario = formulario.ResourceKey;
            model.NombreRol = rol.Nombre;

            model.PermisoList.ToList().ForEach(p =>
            {
                formulario.PermisoList.FirstOrDefault(q => q.TipoPermiso == p.Tipo).Estado = estadoActivo;
                rol.PermisoRolList.FirstOrDefault(q => q.TipoPermiso == p.Tipo && q.FormularioId == model.FormularioId).Estado = estadoActivo;
            });

            listaItemTabla.ForEach(p =>
            {
                model.PermisoList.Add(new PermisoDto
                {
                    Tipo = Convert.ToInt32(p.Valor),
                    Nombre = p.Nombre
                });
            });

            permisos.ForEach(p => 
            {
                model.PermisoList.ToList().ForEach(q => 
                {
                    if (p.TipoPermiso == q.Tipo)
                        q.Estado = true;
                });
            });

            return model;
        }

        [CommitsOperationAspect]
        public void ActualizarPermisos(PermisoRolDto model)
        {
            const int estadoActivo = (int)TipoEstado.Activo;
            const int estadoInActivo = (int)TipoEstado.Inactivo;
            const int permisoMostrar = (int)TipoPermiso.Mostrar;

            var rol = _rolService.Get(model.RolId);
            var formulario = _formularioService.Get(model.FormularioId);
            
            if (model.PermisoList.Count > 0 && model.PermisoList.All(p => p.Tipo != ((int) TipoPermiso.Mostrar)))
            {
                model.PermisoList.Add(new PermisoDto { Tipo = permisoMostrar, Estado = true });
            }

            rol.PermisoRolList
                .Where(p => p.FormularioId == model.FormularioId)
                .ToList()
                .ForEach(p => p.Estado = estadoInActivo);

            foreach (var permiso in model.PermisoList)
            {
                var formularioPermiso = formulario.PermisoList.FirstOrDefault(p => p.TipoPermiso == permiso.Tipo);
                if (formularioPermiso != null)
                {
                    formularioPermiso.Estado = estadoActivo;
                }

                var rolPermiso = rol.PermisoRolList.FirstOrDefault(p => p.TipoPermiso == permiso.Tipo && p.FormularioId == model.FormularioId);
                if (rolPermiso != null)
                {
                    rolPermiso.Estado = estadoActivo;
                }
            }
        }

        #endregion

        #region Métodos Privados

        private List<FormularioDto> AsignarPermisosFormularios(List<FormularioDto> formularios, List<PermisoFormularioDto> permisosFormulariosRol)
        {
            var listaFormularioDto = new List<FormularioDto>();

            foreach (var formulario in formularios)
            {
                formulario.PermisoList = permisosFormulariosRol.Where(q => q.FormularioId == formulario.Id).ToList();

                if (
                    formulario.PermisoList.Any(
                        p => p.TipoPermiso == (int)TipoPermiso.Mostrar && p.Estado == (int)TipoEstado.Activo))
                {
                    if (formulario.FormulariosHijosList.Count > 0)
                    {
                        formulario.FormulariosHijosList = AsignarPermisosFormularios(formulario.FormulariosHijosList,
                            permisosFormulariosRol);

                        if (formulario.FormulariosHijosList.Count > 0)
                            listaFormularioDto.Add(formulario);
                    }
                    else
                    {
                        listaFormularioDto.Add(formulario);
                    }
                }
            }

            return listaFormularioDto;
        }

        private List<FormularioDto> GenerateTreeView(List<Formulario> formularioDomain)
        {
            const int estadoActivo = (int)TipoEstado.Activo;

            return (from modulo in formularioDomain
                    where !modulo.FormularioParentId.HasValue && modulo.Estado == estadoActivo
                    select new FormularioDto
                    {
                        Id = modulo.Id,
                        Icono = modulo.Icono,
                        ResourceKey = modulo.ResourceKey,
                        Direccion = modulo.Direccion,
                        FormulariosHijosList = GenerateChildren(modulo.FormulariosHijosList),
                        Orden = modulo.Orden
                    }).ToList();
        }

        private List<FormularioDto> GenerateChildren(IEnumerable<Formulario> childrenList)
        {
            const int estadoActivo = (int)TipoEstado.Activo;

            return (from children in childrenList
                    where children.Estado == estadoActivo
                    select new FormularioDto
                    {
                        Id = children.Id,
                        Icono = children.Icono,
                        ResourceKey = children.ResourceKey,
                        Direccion = children.Direccion,
                        FormulariosHijosList = GenerateChildren(children.FormulariosHijosList),
                        Orden = children.Orden
                    }).ToList();
        }

        #endregion
    }
}
