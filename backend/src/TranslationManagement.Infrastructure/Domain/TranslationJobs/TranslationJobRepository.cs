using Microsoft.EntityFrameworkCore;
using TranslationManagement.Infrastructure.Database;
using TranslationManagerClean.Domain.TranslationJobs;

namespace TranslationManagement.Infrastructure.Domain.TranslationJobs;

public class TranslationJobRepository : Repository<TranslationJob>, ITranslationJobRepository
{
    public TranslationJobRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<TranslationJob?> GetByIdAsync(int translationJobId)
    {
        return await GetAll()
            .FirstOrDefaultAsync(tj => tj.Id == translationJobId);    
    }
}