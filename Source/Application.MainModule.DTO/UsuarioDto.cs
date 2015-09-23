using Application.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Application.MainModule.DTO.Resources;
using Infrastructure.CrossCutting.Resources.Conventions;

namespace Application.MainModule.DTO
{
    [Serializable]
    [MetadataConventions(ResourceType = typeof(UsuarioDtoResources))]
    public class UsuarioDto : EntityDto<int>
    {
        [Display]
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string UserName { get; set; }

        [Display]
        [StringLength(50, MinimumLength = 4)]
        public string Password { get; set; }

        [Required]
        [Display]
        [EmailAddress]
        [StringLength(100, MinimumLength = 4)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display]
        [Range(1, int.MaxValue)]
        public int RolId { get; set; }

        [Display]
        public int Estado { get; set; }

        public string RolNombre { get; set; }

        public string NombreCompleto { get; set; }

        public string UsuarioRegistro { get; set; }

        public string Accion { get; set; }

        public IEnumerable<RolDto> RolDtos { get; set; }
        public IEnumerable<KeyValuePair<string, string>> Estados { get; set; }
    }
}
