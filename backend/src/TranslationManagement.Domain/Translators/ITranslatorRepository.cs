using TranslationManagement.Domain.Common;

namespace TranslationManagement.Domain.Translators;

public interface ITranslatorRepository : IRepository<Translator>
{
    Task<Translator?> GetByIdAsync(int translatorId);
}