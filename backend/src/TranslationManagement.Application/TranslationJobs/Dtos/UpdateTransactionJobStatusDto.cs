using System.ComponentModel.DataAnnotations;
using TranslationManagement.Domain.TranslationJobs;

namespace TranslationManagement.Application.TranslationJobs.Dtos;

public sealed record UpdateTransactionJobStatusDto : IValidatableObject
{
    public TranslationJobStatus Status { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Status == null)
        {
            yield return new ValidationResult(
                "Status is required",
                new[] {nameof(Status)});
        }
    }
}