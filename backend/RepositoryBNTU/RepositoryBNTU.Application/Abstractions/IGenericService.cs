namespace RepositoryBNTU.Application.Abstractions;

public interface IGenericService<T, in TF>
    where T : class
    where TF : class
{
    public Task<T?> GetByIdAsync(Guid id);
    public Task<IEnumerable<T>> GetAllAsync(TF filter);
    public Task CreateAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(Guid id);
}