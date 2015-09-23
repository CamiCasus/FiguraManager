using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.Enums;

namespace DataBase.Generator.Core
{
    public class ModuloBase : IModulo
    {
        private Formulario _moduloFormulario;

        protected string IconoModulo { get; set; }
        protected List<Rol> RolesConPermiso { get; set; }
        protected List<IOperation> Operations;
        protected string ResourceKey { get; set; }

        private const int Activo = (int)TipoEstado.Activo;

        private void RegistrarModulo()
        {
            _moduloFormulario = new Formulario
            {
                FormulariosHijosList = new LinkedList<Formulario>(),
                ResourceKey = ResourceKey,
                Direccion = string.Empty,
                Icono = IconoModulo,
                Orden = 0,
                FormularioParentId = null,
                Estado = Activo,
                PermisoList = new List<PermisoFormulario>
                {
                    new PermisoFormulario
                    {
                        TipoPermiso = (int)TipoPermiso.Mostrar,
                        Estado = Activo,
                        PermisoFormularioRolList = RolesConPermiso.Select(p =>
                            new PermisoFormularioRol
                            {
                                Rol = p,
                                Estado = p.Estado
                            }).ToList()
                    }
                }
            };
        }

        private void RegistrarOperaciones()
        {
            foreach (var operacion in Operations)
            {
                operacion.Registrar(_moduloFormulario);
            }
        }

        public void Registrar(DbContext dbContext)
        {
            RegistrarModulo();
            RegistrarOperaciones();

            dbContext.Set<Formulario>().Add(_moduloFormulario);
        }
    }
}