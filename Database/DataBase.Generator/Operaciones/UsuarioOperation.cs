//using DataBase.Generator.Core;
//using DataBase.Generator.Enums;
//using Domain.MainModule.Entities;
//using Infrastructure.CrossCutting.Enums;
//using System.Collections.Generic;

//namespace DataBase.Generator.Operaciones
//{
//    public class UsuarioOperation : OperationBase
//    {
//        public UsuarioOperation(List<Rol> rolesConPermiso)
//        {
//            RolesConPermiso = rolesConPermiso;
//            ResourceKey = TipoOperacion.UsuarioOperation.ToString();
//            Direccion = UrlOperationManager.OperationsUrl[TipoOperacion.UsuarioOperation];
//            Icono = IconosSvgConstantes.FormularioOperation;

//            PermisosOperacion = new List<TipoPermiso>
//            {
//                TipoPermiso.Mostrar,
//                TipoPermiso.Crear,
//                TipoPermiso.Editar,
//                TipoPermiso.Eliminar,
//                TipoPermiso.Imprimir
//            };
//        }
//    }
//}

using System.Collections.Generic;
using DataBase.Generator.Core;
using DataBase.Generator.Enums;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.Enums;

namespace DataBase.Generator.Operaciones
{
    public class UsuarioOperation : OperationBase
    {
        public UsuarioOperation(List<Rol> rolesConPermiso)
        {
            RolesConPermiso = rolesConPermiso;
            ResourceKey = TipoOperacion.UsuarioOperation.ToString();
            Direccion = UrlOperationManager.OperationsUrl[TipoOperacion.UsuarioOperation];
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