using TranslationManagement.Domain.Common;
using TranslationManagement.Domain.TranslationJobs.Rules;
using TranslationManagement.Domain.Translators;

namespace TranslationManagement.Domain.TranslationJobs;

public class TranslationJob : BaseEntity
{
    public static TranslationJob Create(string customerName, string originalContent, decimal pricePerCharacter = 0.01m)
    {
        return new TranslationJob(customerName, originalContent, pricePerCharacter);
    }

    private TranslationJob(string customerName, string originalContent, decimal pricePerCharacter)
    {
        CheckRule(new PriceMustBeWithinRangeRule(pricePerCharacter));

        CustomerName = customerName;
        OriginalContent = originalContent;
        Status = TranslationJobStatus.NEW;
        Price = originalContent.Length * pricePerCharacter;
    }

    private TranslationJob()
    {
        // Only for ef
    }

    public string CustomerName { get; private set; }
    public TranslationJobStatus Status { get; private set; }
    public string OriginalContent { get; private set; }
    public string? TranslatedContent { get; private set; }
    public decimal Price { get; private set; }

    public int? TranslatorId { get; private set; }

    public virtual Translator? Translator { get; private set; }

    public bool TryUpdateStatus(TranslationJobStatus status)
    {
        var translationJobStateMachine = new TranslationJobStateMachine();
        if (!translationJobStateMachine.IsValidTransition(Status, status)) return false;
        Status = status;
        return true;
    }

    public void AssignTranslator(Translator translator)
    {
        CheckRule(new OnlyCertifiedTranslatorsCanWorkOnJobRule(translator));
        Translator = translator;
    }
}