using TranslationManagement.Application.UnitOfWork;

namespace TranslationManagement.Infrastructure.Database.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;

    public UnitOfWork(
        AppDbContext context)
    {
        this.context = context;
    }
    
    public async Task<int> CommitAsync(
        CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}