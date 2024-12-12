using Microsoft.EntityFrameworkCore;
using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Persistence.Repositories;

public class PublicationRepository(RepositoryDbContext context) : IPublicationRepository
{
    public async Task<Publication?> GetByIdAsync(Guid id)
    {
        return await context.Publications
            .Include(p => p.Author)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Publication>> GetAllAsync()
    {
        return await context.Publications
            .Include(p => p.Author)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(Publication entity)
    {
        await context.Publications.AddAsync(entity);
    }

    public void Update(Publication entity)
    {
        context.Publications.Update(entity);
    }

    public void Delete(Publication entity)
    {
        context.Publications.Remove(entity);
    }

    public async Task<Publication?> GetPublicationByIsbnAsync(string isbn)
    {
        return await context.Publications
            .Include(p => p.Author)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.ISBN == isbn);
    }

    public async Task<IEnumerable<Publication>> GetPublicationsByCategoryAsync(Guid categoryId)
    {
        return await context.Publications
            .Include(p => p.Author)
            .AsNoTracking()
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync();
    }
}