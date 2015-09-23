using Application.Core;

namespace Application.MainModule.DTO
{
    public class UsuarioPaginationDto : EntityDto<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RolNombre { get; set; }
    }
}