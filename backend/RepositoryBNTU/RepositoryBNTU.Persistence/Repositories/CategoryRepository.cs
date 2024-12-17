using Microsoft.EntityFrameworkCore;
using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Persistence.Repositories;

public class CategoryRepository(RepositoryDbContext context) : ICategoryRepository
{
    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await context.Categories
            .AsNoTracking()
            .Include(c => c.Publications)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await context.Categories
            .AsNoTracking()
            .Include(c => c.Publications)
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
            .Include(c => c.Publications)
            .FirstOrDefaultAsync(c => c.Name == name);
    }
}