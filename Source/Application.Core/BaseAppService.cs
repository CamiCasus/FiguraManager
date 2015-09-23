using Domain.Core.Validations;

namespace Application.Core
{
    public class BaseAppService
    {
        public ValidationResultDto ValidationResultDto(ValidationResult resultService)
        {
            var validationResultDto = new ValidationResultDto
            {
                IsValid = resultService.IsValid,
                Errors = resultService.ErrorsStr
            };
            return validationResultDto;
        }

        public ValidationResultDto ValidationResultDto<TEntity, TDto>(ValidationResultWithType<TEntity> resultService)
        {
            var validationResultDto = new ValidationResultDto
            {
                IsValid = resultService.IsValid,
                Errors = resultService.ErrorsStr,
                Data = MapperHelper.Map<TEntity, TDto>(resultService.Data)
            };
            return validationResultDto;
        }
    }
}