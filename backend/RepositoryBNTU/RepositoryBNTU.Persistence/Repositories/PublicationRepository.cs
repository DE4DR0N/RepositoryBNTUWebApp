using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Persistence.Repositories;

public class PublicationRepository(RepositoryDbContext context) : IPublicationRepository
{
    public async Task<Publication> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Publication>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Publication entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Publication entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Publication entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Publication> GetPublicationByIsbnAsync(string isbn)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Publication>> GetPublicationsByCategoryAsync(Guid categoryId)
    {
        throw new NotImplementedException();
    }
}