using Microsoft.EntityFrameworkCore;
using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;
using RepositoryBNTU.Persistence.Extensions;

namespace RepositoryBNTU.Persistence.Repositories;

public class PublicationRepository(RepositoryDbContext context) : IPublicationRepository
{
    public async Task<Publication?> GetByIdAsync(Guid id)
    {
        return await context.Publications
            .Include(p => p.Author)
            .Include(p => p.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Publication>> GetAllAsync(PublicationFilter filter)
    {
        return await context.Publications
            .Filter(filter)
            .Include(p => p.Author)
            .Include(p => p.Category)
            .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Publication>> GetAllAsync(PublicationFilter filter, int? skip, int? take)
    {
        return await context.Publications
            .Filter(filter)
            .Paginate(skip, take)
            .Include(p => p.Author)
            .Include(p => p.Category)
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
            .Include(p => p.Category)
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