namespace TranslationManagerClean.Domain.Common;

public interface IRepository<T> where T: BaseEntity
{
    IQueryable<T> GetAll();
    void Add(T entity);
}