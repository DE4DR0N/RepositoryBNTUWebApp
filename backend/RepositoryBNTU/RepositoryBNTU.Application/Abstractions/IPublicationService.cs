using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Application.Abstractions;

public interface IPublicationService : IGenericService<Publication>
{
    public Task<Publication?> GetPublicationByIsbnAsync(string isbn);
    public Task<IEnumerable<Publication>> GetPublicationsByCategoryAsync(Guid categoryId);
}