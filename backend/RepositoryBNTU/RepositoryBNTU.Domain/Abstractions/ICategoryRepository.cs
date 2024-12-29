using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Domain.Abstractions;

public interface ICategoryRepository : IGenericRepository<Category, CategoryFilter>
{
    public Task<Category?> GetCategoryByNameAsync(string name);
}