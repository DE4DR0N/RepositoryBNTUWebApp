using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Domain.Abstractions;

public interface IPublicationRepository : IGenericRepository<Publication>
{
    public Task<Publication?> GetPublicationByIsbnAsync(string isbn);
    public Task<IEnumerable<Publication>> GetPublicationsByCategoryAsync(Guid categoryId);
}