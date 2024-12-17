using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Domain.Abstractions;

public interface ICategoryRepository : IGenericRepository<Category>
{
    public Task<Category?> GetCategoryByNameAsync(string name);
}