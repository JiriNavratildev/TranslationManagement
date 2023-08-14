using System.ComponentModel.DataAnnotations;

namespace TranslationManagement.Application.Common;

public abstract class BaseService
{
    protected void ValidateDto<TDto>(TDto dto) where TDto : IValidatableObject
    {
        var validationContext = new ValidationContext(dto, null, null);
        var validationResults = new List<ValidationResult>();
            
        if (!Validator.TryValidateObject(dto, validationContext, validationResults, true))
        {
            // I would probably join all error messages, omitting that in sake of simplicity
            foreach (var validationResult in validationResults)
            {
                throw new ValidationException(validationResult.ErrorMessage);
            }
        }
    }
}