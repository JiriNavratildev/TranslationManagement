using Microsoft.EntityFrameworkCore;
using TranslationManagement.Infrastructure.Database;
using TranslationManagerClean.Domain.Translators;

namespace TranslationManagement.Infrastructure.Domain.Translators;

public class TranslatorRepository : Repository<Translator>, ITranslatorRepository
{
    public TranslatorRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<Translator?> GetByIdAsync(int translatorId)
    {
        return await GetAll()
            .FirstOrDefaultAsync(tj => tj.Id == translatorId);
    }
}