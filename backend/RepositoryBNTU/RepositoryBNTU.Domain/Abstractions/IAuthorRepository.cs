using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Domain.Abstractions;

public interface IAuthorRepository : IGenericRepository<Author>
{
    public Task<IEnumerable<Publication>> GetPublicationsByAuthorAsync(Guid authorId);
}