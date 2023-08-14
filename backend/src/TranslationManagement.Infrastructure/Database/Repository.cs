using Microsoft.EntityFrameworkCore;
using TranslationManagement.Domain.Common;

namespace TranslationManagement.Infrastructure.Database;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> dbSet;

    public Repository(AppDbContext appDbContext)
    {
        dbSet = appDbContext.Set<T>();
    }

    public IQueryable<T> GetAll() => dbSet.AsQueryable();

    public void Add(T entity) => dbSet.Add(entity);
}