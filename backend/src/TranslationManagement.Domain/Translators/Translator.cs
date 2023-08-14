using TranslationManagement.Domain.Common;
using TranslationManagement.Domain.TranslationJobs;

namespace TranslationManagement.Domain.Translators;

public class Translator : BaseEntity
{
    public static Translator Create(string name, decimal hourlyRate, string creditCardNumber)
    {
        return new Translator(name, hourlyRate, creditCardNumber);
    }

    private Translator(string name, decimal hourlyRate, string creditCardNumberEncrypted)
    {
        TranslationJobs = new List<TranslationJob>();
        Name = name;
        HourlyRate = hourlyRate;
        // Here we perform credit card number encryption
        CreditCardNumberEncrypted = creditCardNumberEncrypted;
    }

    private Translator()
    {
        // Only for ef
    }
    
    public string Name { get; private set; }
    public decimal HourlyRate { get; private set; }
    public TranslatorStatus Status { get; private set; }
    public string CreditCardNumberEncrypted { get; private set; }
    
    public ICollection<TranslationJob> TranslationJobs { get; private set; }

    public void SetStatus(TranslatorStatus status)
    {
        Status = status;
    }
}