using TranslationManagement.Domain.Common;

namespace TranslationManagement.Domain.TranslationJobs;

public interface ITranslationJobRepository : IRepository<TranslationJob>
{
    Task<TranslationJob?> GetByIdAsync(int translationJobId);
}