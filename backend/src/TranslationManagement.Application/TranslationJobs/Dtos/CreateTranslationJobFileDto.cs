using System.ComponentModel.DataAnnotations;
using TranslationManagement.Application.Files;

namespace TranslationManagement.Application.TranslationJobs.Dtos;

public sealed record CreateTranslationJobFileDto : IValidatableObject
{
    public string FileContent { get; init; }
    public FileType FileType { get; init; }
    public string? CustomerName { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        //..
        if (FileType == FileType.TXT && string.IsNullOrEmpty(CustomerName))
        {
            yield return new ValidationResult(
                "CustomerName is required when TXT file is used.",
                new[] {nameof(CustomerName)});
        }

        //..
    }
}