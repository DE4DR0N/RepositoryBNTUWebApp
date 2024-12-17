namespace RepositoryBNTU.Application.Abstractions;

public interface IGenericService<T> where T : class
{
    public Task<T?> GetByIdAsync(Guid id);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task CreateAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(Guid id);
}