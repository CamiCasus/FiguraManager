using DataBase.Generator.Core;
using DataBase.Generator.Enums;
using DataBase.Generator.Operaciones;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.Enums;
using System.Collections.Generic;

namespace DataBase.Generator.Modulos
{
    public class SeguridadModulo : ModuloBase
    {
        public SeguridadModulo()
        {
            var rolAdm = RolesStorage.Roles[TipoRol.Administrador];
            var roles = new List<Rol> { rolAdm};

            RolesConPermiso = roles;
            ResourceKey = TipoModulo.SeguridadModulo.ToString();
            IconoModulo = IconosSvgConstantes.ModuloSeguridad;

            Operations = new List<IOperation>
            {
                new UsuarioOperation(roles),
                new FormularioOperation(roles)
            };
        }
    }
}