using DataBase.Generator.Core;
using DataBase.Generator.Enums;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.Enums;
using System.Collections.Generic;

namespace DataBase.Generator.Operaciones
{
    public class FormularioOperation : OperationBase
    {
        public FormularioOperation(List<Rol> rolesConPermiso)
        {
            RolesConPermiso = rolesConPermiso;
            Icono = IconosSvgConstantes.FormularioOperation;
            ResourceKey = TipoOperacion.FormularioOperation.ToString();
            Direccion = UrlOperationManager.OperationsUrl[TipoOperacion.FormularioOperation];

            PermisosSeccionOperacion = new Dictionary<int, List<TipoPermiso>>
            {
                {
                    1,
                    new List<TipoPermiso>
                    {
                        TipoPermiso.Mostrar,
                        TipoPermiso.Crear,
                        TipoPermiso.Editar,
                        TipoPermiso.Eliminar,
                        TipoPermiso.Imprimir
                    }
                }
            };
        }
    }
}