using System.Linq;
using Domain.Core.OrderBy;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.Enums;

namespace Domain.MainModule.OrdersBy
{
    public class UsuarioPaginationDtoOrderBy : OrderByEntity<Usuario>
    {
        public UsuarioPaginationDtoOrderBy()
            : base("Id", TipoOrdenamiento.Descending)
        {

            AddOrder("RolNombre", p => p.RolUsuarioList.FirstOrDefault().Rol.Nombre);
            AddOrder("UserName", p => p.UserName);
            AddOrder("Email", p => p.Email);
        }
    }
}