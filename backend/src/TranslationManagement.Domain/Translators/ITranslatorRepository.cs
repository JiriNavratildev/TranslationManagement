using TranslationManagerClean.Domain.Common;

namespace TranslationManagerClean.Domain.Translators;

public interface ITranslatorRepository : IRepository<Translator>
{
    Task<Translator?> GetByIdAsync(int translatorId);
}