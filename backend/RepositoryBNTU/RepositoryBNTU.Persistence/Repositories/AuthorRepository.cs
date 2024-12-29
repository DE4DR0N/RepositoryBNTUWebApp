using Microsoft.EntityFrameworkCore;
using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;
using RepositoryBNTU.Persistence.Extensions;

namespace RepositoryBNTU.Persistence.Repositories;

public class AuthorRepository(RepositoryDbContext context) : IAuthorRepository
{
    public async Task<Author?> GetByIdAsync(Guid id)
    {
        return await context.Authors
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Author>> GetAllAsync(AuthorFilter filter)
    {
        return await context.Authors
            .Filter(filter)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(Author entity)
    {
        await context.Authors.AddAsync(entity);
    }

    public void Update(Author entity)
    {
        context.Authors.Update(entity);
    }

    public void Delete(Author entity)
    {
        context.Authors.Remove(entity);
    }

    public async Task<IEnumerable<Publication>> GetPublicationsByAuthorAsync(Guid authorId)
    {
        return await context.Publications
            .Include(p => p.Author)
            .Where(p => p.AuthorId == authorId)
            .AsNoTracking()
            .ToListAsync();
    }
}