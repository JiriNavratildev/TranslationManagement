using TranslationManagement.Domain.TranslationJobs;

namespace TranslationManagerClean.Domain.TranslationJobs;

internal class TranslationJobStateMachine
{
    private readonly Dictionary<TranslationJobStatus, HashSet<TranslationJobStatus>> validTransitions = new()
    {
        { TranslationJobStatus.NEW, new HashSet<TranslationJobStatus> { TranslationJobStatus.IN_PROGRESS } },
        { TranslationJobStatus.IN_PROGRESS, new HashSet<TranslationJobStatus> { TranslationJobStatus.COMPLETED } },
        { TranslationJobStatus.COMPLETED, new HashSet<TranslationJobStatus>() }
    };

    public bool IsValidTransition(TranslationJobStatus fromStatus, TranslationJobStatus toStatus)
    {
        return validTransitions.ContainsKey(fromStatus) && validTransitions[fromStatus].Contains(toStatus);
    }
}