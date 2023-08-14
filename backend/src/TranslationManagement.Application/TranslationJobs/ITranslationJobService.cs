using TranslationManagement.Application.TranslationJobs.Dtos;

namespace TranslationManagement.Application.TranslationJobs;

public interface ITranslationJobService
{
    Task<List<TranslationJobDto>> GetAsync();
    Task<TranslationJobDto> CreateAsync(CreateTranslationJobDto createTranslationJobDto);
    Task<TranslationJobDto> CreateAsync(CreateTranslationJobFileDto createTranslationJobFileDto);
    Task<TranslationJobDto> UpdateStatusAsync(int jobId, UpdateTransactionJobStatusDto updateTransactionJobStatusDto);
    Task AssignTranslatorAsync(int jobId, int translatorId);
}