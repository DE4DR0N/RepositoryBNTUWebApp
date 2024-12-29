using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Domain.Abstractions;

public interface IPublicationRepository : IGenericRepository<Publication, PublicationFilter>
{
    public Task<IEnumerable<Publication>> GetAllAsync(PublicationFilter filter, int? skip, int? take);
    public Task<Publication?> GetPublicationByIsbnAsync(string isbn);
    public Task<IEnumerable<Publication>> GetPublicationsByCategoryAsync(Guid categoryId);
}