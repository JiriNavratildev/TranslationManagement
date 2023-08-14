using System.ComponentModel.DataAnnotations;
using TranslationManagement.Domain.Translators;

namespace TranslationManagement.Application.Translators.Dtos;

public sealed record CreateTranslatorDto : IValidatableObject
{
    public string Name { get; init; }
    public decimal HourlyRate { get; init; }
    public TranslatorStatus Status { get; init; }
    public string CreditCardNumber { get; init; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            yield return new ValidationResult(
                "Name is required",
                new[] { nameof(Name) });
        }
        
        if (HourlyRate < 0)
        {
            yield return new ValidationResult(
                "HourlyRate must be positive number",
                new[] { nameof(HourlyRate) });
        }
    }
}