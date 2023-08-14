using TranslationManagement.Domain.Translators;

namespace TranslationManagement.Application.Translators.Dtos;

public sealed record TranslatorDto(int Id, string Name, decimal HourlyRate, TranslatorStatus Status);