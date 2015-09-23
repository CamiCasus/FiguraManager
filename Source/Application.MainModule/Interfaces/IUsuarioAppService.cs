using Application.Core;
using Application.Core.Interfaces;
using Application.MainModule.DTO;
using System.Collections.Generic;

namespace Application.MainModule.Interfaces
{
    public interface IUsuarioAppService : IAppService<UsuarioDto, int>, IPaginationAppService<UsuarioPaginationDto>
    {
        UsuarioLoginDto ValidateUser(string username, string password);
        UsuarioDto GetByEmail(string email);
        ValidationResultDto UpdatePassword(UsuarioDto entityDto);
        UsuarioDto GetUsuarioDtoCrear();
        UsuarioDto GetUsuarioDtoEditar(int usuarioId);
        IEnumerable<UsuarioDto> GetUsuarioReport(UsuarioDto model);
    }
}
