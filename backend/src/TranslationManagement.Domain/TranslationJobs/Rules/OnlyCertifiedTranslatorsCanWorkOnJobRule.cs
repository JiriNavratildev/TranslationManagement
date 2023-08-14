using TranslationManagement.Domain.Common;
using TranslationManagement.Domain.Translators;

namespace TranslationManagement.Domain.TranslationJobs.Rules;

public class OnlyCertifiedTranslatorsCanWorkOnJobRule : IBusinessRule
{
    private readonly Translator translator;

    public OnlyCertifiedTranslatorsCanWorkOnJobRule(Translator translator)
    {
        this.translator = translator;
    }

    public bool IsBroken() => translator.Status != TranslatorStatus.CERTIFIED;

    public string Message => "Only Certified translators can work on jobs";
}