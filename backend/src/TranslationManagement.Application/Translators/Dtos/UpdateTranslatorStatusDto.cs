using TranslationManagerClean.Domain.Translators;

namespace TranslationManagement.Application.Translators.Dtos;

public sealed record UpdateTranslatorStatusDto
{
    public TranslatorStatus TranslatorStatus { get; set; }
}