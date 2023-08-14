using TranslationManagerClean.Domain.Common;

namespace TranslationManagerClean.Domain.TranslationJobs;

public interface ITranslationJobRepository : IRepository<TranslationJob>
{
    Task<TranslationJob?> GetByIdAsync(int translationJobId);
}