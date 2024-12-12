using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Persistence.Repositories;

public class AuthorRepository(RepositoryDbContext context) : IAuthorRepository
{
    public async Task<Author> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Author entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Author entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Author entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Publication>> GetPublicationsByAuthorAsync(Guid authorId)
    {
        throw new NotImplementedException();
    }
}