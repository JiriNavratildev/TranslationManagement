using TranslationManagerClean.Domain.Common;

namespace TranslationManagerClean.Domain.TranslationJobs.Rules;

public class PriceMustBeWithinRangeRule : IBusinessRule
{
    private const decimal MinPricePerCharacterInclusive = 0.01m;
    private const decimal MaxPricePerCharacterInclusive = 0.05m;
    
    private readonly decimal pricePerCharacter;

    public PriceMustBeWithinRangeRule(decimal pricePerCharacter)
    {
        this.pricePerCharacter = pricePerCharacter;
    }

    public bool IsBroken() => pricePerCharacter < MinPricePerCharacterInclusive ||
                              pricePerCharacter > MaxPricePerCharacterInclusive;

    public string Message => $"Price must be with {MinPricePerCharacterInclusive} - {MaxPricePerCharacterInclusive} range.";
}