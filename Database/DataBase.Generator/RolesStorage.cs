using System.Collections.Generic;
using Infrastructure.CrossCutting.Enums;
using Domain.MainModule.Entities;

namespace DataBase.Generator
{
    public static class RolesStorage
    {
        static RolesStorage()
        {
            Roles = new Dictionary<TipoRol, Rol>();
        }

        public static Dictionary<TipoRol, Rol> Roles { get; set; }
    }
}