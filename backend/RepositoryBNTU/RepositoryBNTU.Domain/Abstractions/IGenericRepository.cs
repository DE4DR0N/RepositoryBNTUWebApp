namespace RepositoryBNTU.Domain.Abstractions;

public interface IGenericRepository<T> where T : class
{
    public Task<T> GetByIdAsync(Guid id);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task AddAsync(T entity);
    public void Update(T entity);
    public void Delete(T entity);
}