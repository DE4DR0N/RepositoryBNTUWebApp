using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Application.Abstractions;

public interface ICategoryService : IGenericService<Category, CategoryFilter>
{
    public Task<Category?> GetCategoryByNameAsync(string name);
}