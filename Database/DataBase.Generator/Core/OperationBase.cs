using System.Collections.Generic;
using System.Linq;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.Enums;

namespace DataBase.Generator.Core
{
    public class OperationBase : IOperation
    {
        private const int Activo = (int)TipoEstado.Activo;
        protected List<Rol> RolesConPermiso { get; set; }
        protected Dictionary<int, List<TipoPermiso>> PermisosSeccionOperacion { get; set; }
        protected List<Formulario> FormulariosHijosList;

        protected string Icono { get; set; }
        protected string ResourceKey { get; set; }
        protected string Direccion { get; set; }

        public void Registrar(Formulario parent)
        {
            parent.FormulariosHijosList.Add(ConverterOperationToFormulario());
        }

        public Formulario ConverterOperationToFormulario()
        {
            return new Formulario
            {
                ResourceKey = ResourceKey,
                Direccion = Direccion,
                Icono = string.Empty,
                Orden = 1,
                Estado = Activo,
                PermisoList = PermisosSeccionOperacion.SelectMany(p => p.Value.Select(q =>
                    new PermisoFormulario
                    {
                        Seccion = p.Key,
                        TipoPermiso = (int) q,
                        Estado = Activo,
                        PermisoFormularioRolList =
                            RolesConPermiso.Select(r => new PermisoFormularioRol {Rol = r, Estado = Activo}).ToList()
                    })).ToList(),
                FormulariosHijosList = FormulariosHijosList
            };
        }
    }
}