using Application.MainModule.DTO;
using System.Collections.Generic;

namespace Application.MainModule.Interfaces
{
    public interface IFormularioAppService 
    {
        IEnumerable<FormularioDto> GetByUsuario(int idUsuario);
        IEnumerable<FormularioDto> All();
        IList<FormularioDto> AllToTree();
        PermisoRolDto ObtenerPermisos(PermisoRolDto model);
        void ActualizarPermisos(PermisoRolDto model);
    }
}
