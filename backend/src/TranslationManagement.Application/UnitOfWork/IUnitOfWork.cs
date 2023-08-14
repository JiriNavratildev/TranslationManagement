namespace TranslationManagement.Application.UnitOfWork;

public interface IUnitOfWork
{
    Task<int> CommitAsync(
        CancellationToken cancellationToken = default);
}