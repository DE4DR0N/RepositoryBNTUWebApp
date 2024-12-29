using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Application.Abstractions;

public interface IPublicationService : IGenericService<Publication, PublicationFilter>
{
    Task<(IEnumerable<Publication> publications, int totalPages)> GetAllAsync(PublicationFilter filter, int? page, int? pageSize);
    public Task<IEnumerable<Publication>> SearchAsync(string searchTerm);
    public Task<Publication?> GetPublicationByIsbnAsync(string isbn);
    public Task<IEnumerable<Publication>> GetPublicationsByCategoryAsync(Guid categoryId);
}