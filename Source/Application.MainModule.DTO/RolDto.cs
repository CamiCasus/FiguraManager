using Application.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.MainModule.DTO
{
    [Serializable]
    public class RolDto : EntityDto<int>
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Nombre { get; set; }

        [Required]
        public int Estado { get; set; }
    }
}
