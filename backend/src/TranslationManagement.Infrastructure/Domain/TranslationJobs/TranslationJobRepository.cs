using Microsoft.EntityFrameworkCore;
using TranslationManagement.Domain.TranslationJobs;
using TranslationManagement.Infrastructure.Database;

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