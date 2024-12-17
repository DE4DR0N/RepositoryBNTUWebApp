using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Application.Abstractions;

public interface IAuthorService : IGenericService<Author>
{
    public Task<IEnumerable<Publication>> GetPublicationsByAuthorAsync(Guid authorId);
}