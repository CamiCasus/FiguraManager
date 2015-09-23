using Application.Core;
using System;

namespace Application.MainModule.DTO
{
    [Serializable]
    public class UsuarioLoginDto : EntityDto<int>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
        public string RolNombre { get; set; }
        public int Estado { get; set; }
        public string TimeZoneId { get; set; }
        public int TimeZoneGMT { get; set; }
    }
}
