using Application.MainModule.DTO.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.MainModule.DTO
{
    [Serializable]
    public class ForgotPasswordDto
    {
        [Display(Name = "Email", ResourceType = typeof(ForgotPasswordDtoResources))]
        [Required(ErrorMessageResourceName = "EmailRequerido", ErrorMessageResourceType = typeof(ForgotPasswordDtoResources))]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?$", ErrorMessageResourceName = "EmailFormatoIncorrecto", ErrorMessageResourceType = typeof(ForgotPasswordDtoResources))]
        public string Email { get; set; }
    }
}
