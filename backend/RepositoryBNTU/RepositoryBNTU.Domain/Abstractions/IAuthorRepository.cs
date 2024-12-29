using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Domain.Abstractions;

public interface IAuthorRepository : IGenericRepository<Author, AuthorFilter>
{
    public Task<IEnumerable<Publication>> GetPublicationsByAuthorAsync(Guid authorId);
}