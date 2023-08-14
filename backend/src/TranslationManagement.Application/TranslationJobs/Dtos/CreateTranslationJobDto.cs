
using System.ComponentModel.DataAnnotations;

namespace TranslationManagement.Application.TranslationJobs.Dtos;

public class CreateTranslationJobDto : IValidatableObject
{
    public string CustomerName { get; init; }
    public string OriginalContent { get; init; }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(CustomerName))
        {
            yield return new ValidationResult(
                "CustomerName is required",
                new[] { nameof(CustomerName) });
        }
        
        if (string.IsNullOrWhiteSpace(OriginalContent))
        {
            yield return new ValidationResult(
                "OriginalContent is required",
                new[] { nameof(OriginalContent) });
        }
    }
}