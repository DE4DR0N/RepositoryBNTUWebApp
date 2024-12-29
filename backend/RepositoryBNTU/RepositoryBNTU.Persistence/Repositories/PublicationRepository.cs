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
    
    public async Task<(IEnumerable<Publication> publications, int totalPages)> GetAllAsync(PublicationFilter filter, int? page, int? pageSize)
    {
        var size = pageSize ?? 10;
        var totalCount = await context.Publications.Filter(filter).CountAsync(); 
        var totalPages = (int)Math.Ceiling(totalCount / (double)size);
    
        var publications = await context.Publications
            .Filter(filter)
            .Paginate(page, pageSize)
            .Include(p => p.Author)
            .Include(p => p.Category)
            .AsNoTracking()
            .ToListAsync();

        return (publications, totalPages);
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
            .Include(p => p.Category)
            .Include(p => p.Author)
            .AsNoTracking()
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Publication>> SearchAsync(string searchTerm)
    {
        var lowerSearchTerm = searchTerm.ToLower();

        return await context.Publications
            .Include(p => p.Category)
            .Include(p => p.Author)
            .AsNoTracking()
            .Where(p => p.Title.ToLower().Contains(lowerSearchTerm) ||
                        p.Description.ToLower().Contains(lowerSearchTerm) ||
                        p.Category.Name.ToLower().Contains(lowerSearchTerm) ||
                        p.Author.FirstName.ToLower().Contains(lowerSearchTerm) ||
                        p.Author.LastName.ToLower().Contains(lowerSearchTerm))
            .ToListAsync();
    }
}