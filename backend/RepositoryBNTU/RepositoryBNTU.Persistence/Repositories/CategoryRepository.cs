using Microsoft.EntityFrameworkCore;
using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;
using RepositoryBNTU.Persistence.Extensions;

namespace RepositoryBNTU.Persistence.Repositories;

public class CategoryRepository(RepositoryDbContext context) : ICategoryRepository
{
    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Category>> GetAllAsync(CategoryFilter filter)
    {
        return await context.Categories
            .Filter(filter)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(Category entity)
    {
        await context.Categories.AddAsync(entity);
    }

    public void Update(Category entity)
    {
        context.Categories.Update(entity);
    }

    public void Delete(Category entity)
    {
        context.Categories.Remove(entity);
    }

    public async Task<Category?> GetCategoryByNameAsync(string name)
    {
        return await context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Name == name);
    }
}