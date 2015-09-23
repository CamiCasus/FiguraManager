using Application.MainModule.DTO.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.MainModule.DTO
{
    [Serializable]
    //[PropertiesMustMatch("NewPassword", "ConfirmPassword", ErrorMessageResourceName = "Coincidencia", ErrorMessageResourceType = typeof(ChangePasswordDtoResources))]
    public class ChangePasswordDto
    {
        [Display(Name = "ClaveActual", ResourceType = typeof(ChangePasswordDtoResources))]
        [Required(ErrorMessageResourceName = "ClaveActualRequerido", ErrorMessageResourceType = typeof(ChangePasswordDtoResources))]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "ClaveNueva", ResourceType = typeof(ChangePasswordDtoResources))]
        [Required(ErrorMessageResourceName = "ClaveNuevaRequerido", ErrorMessageResourceType = typeof(ChangePasswordDtoResources))]
        //[ValidatePasswordLength]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceName = "ClaveLongitudMinimun", ErrorMessageResourceType = typeof(ChangePasswordDtoResources))]
        public string NewPassword { get; set; }

        [Display(Name = "ConfirmarClaveNueva", ResourceType = typeof(ChangePasswordDtoResources))]
        [Required(ErrorMessageResourceName = "ConfirmarClaveNueva", ErrorMessageResourceType = typeof(ChangePasswordDtoResources))]
        [StringLength(100, MinimumLength = 6, ErrorMessageResourceName = "ConfirmacionClaveLongitudMinimun", ErrorMessageResourceType = typeof(ChangePasswordDtoResources))]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessageResourceName = "Coincidencia", ErrorMessageResourceType = typeof(ChangePasswordDtoResources))]
        public string ConfirmPassword { get; set; }
    }
}
