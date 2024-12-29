namespace RepositoryBNTU.Domain.Abstractions;

public interface IGenericRepository<T, in TF> 
    where T : class
    where TF : class
{
    public Task<T?> GetByIdAsync(Guid id);
    public Task<IEnumerable<T>> GetAllAsync(TF filter);
    public Task AddAsync(T entity);
    public void Update(T entity);
    public void Delete(T entity);
}