using TranslationManagement.Domain.TranslationJobs;
using TranslationManagerClean.Domain.TranslationJobs;

namespace TranslationManagement.Application.TranslationJobs.Dtos;

public sealed record TranslationJobDto(int Id, string CustomerName, TranslationJobStatus Status, string OriginalContent, string? TranslatedContent, decimal Price);