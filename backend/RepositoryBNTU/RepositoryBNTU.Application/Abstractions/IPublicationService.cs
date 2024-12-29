using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Application.Abstractions;

public interface IPublicationService : IGenericService<Publication, PublicationFilter>
{
    public Task<IEnumerable<Publication>> GetAllAsync(PublicationFilter filter, int? page, int? pageSize);
    public Task<Publication?> GetPublicationByIsbnAsync(string isbn);
    public Task<IEnumerable<Publication>> GetPublicationsByCategoryAsync(Guid categoryId);
}