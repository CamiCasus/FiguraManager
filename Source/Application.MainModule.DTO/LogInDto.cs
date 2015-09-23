using Application.MainModule.DTO.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.MainModule.DTO
{
    [Serializable]
    public class LogInDto
    {
        [Display(Name = "Username", ResourceType = typeof(LoginDtoResources))]
        [Required(ErrorMessageResourceName = "UsernameRequerido", ErrorMessageResourceType = typeof(LoginDtoResources))]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(LoginDtoResources))]
        [Required(ErrorMessageResourceName = "PasswordRequerido", ErrorMessageResourceType = typeof(LoginDtoResources))]
        public string Password { get; set; }
    }
}
