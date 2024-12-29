using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Domain.Abstractions;

public interface IPublicationRepository : IGenericRepository<Publication, PublicationFilter>
{
    Task<(IEnumerable<Publication> publications, int totalPages)> GetAllAsync(PublicationFilter filter, int? page, int? pageSize);
    public Task<Publication?> GetPublicationByIsbnAsync(string isbn);
    public Task<IEnumerable<Publication>> GetPublicationsByCategoryAsync(Guid categoryId);
    public Task<IEnumerable<Publication>> SearchAsync(string searchTerm);
}