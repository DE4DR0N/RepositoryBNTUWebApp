using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Application.Abstractions;

public interface ICategoryService : IGenericService<Category>
{
    public Task<Category?> GetCategoryByNameAsync(string name);
}