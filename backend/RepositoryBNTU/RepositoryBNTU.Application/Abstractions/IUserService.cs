using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Application.Abstractions;

public interface IUserService : IGenericService<User, UserFilter>
{
    public Task<User?> GetByEmailAsync(string email);
    public Task<IEnumerable<Publication>> GetPublicationsByUserAsync(Guid userId);
}