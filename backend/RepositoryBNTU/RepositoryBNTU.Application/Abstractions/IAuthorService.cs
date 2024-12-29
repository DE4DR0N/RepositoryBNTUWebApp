using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Application.Abstractions;

public interface IAuthorService : IGenericService<Author, AuthorFilter>
{
    public Task<IEnumerable<Publication>> GetPublicationsByAuthorAsync(Guid authorId);
}