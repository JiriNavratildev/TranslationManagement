using TranslationManagement.Domain.Exceptions;

namespace TranslationManagement.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; private set; }
    
    protected void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}