using TranslationManagement.Application.TranslationJobs.Dtos;
using TranslationManagement.Application.Translators.Dtos;
using TranslationManagement.Domain.Translators;

namespace TranslationManagement.Application.Translators;

public interface ITranslatorService
{
    Task<List<TranslatorDto>> GetAsync();
    Task<TranslatorDto?> GetByNameAsync(string name);
    Task<TranslatorDto> CreateAsync(CreateTranslatorDto createTranslatorDto);
    Task<TranslatorDto> UpdateStatusAsync(int translatorId, TranslatorStatus status);
    Task<List<TranslationJobDto>> GetTranslatorJobsAsync(int translatorId);
}