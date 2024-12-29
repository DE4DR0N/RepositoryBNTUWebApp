using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Domain.Abstractions;

public interface IUserRepository : IGenericRepository<User, UserFilter>
{
    public Task<User?> GetByEmailAsync(string email);
    public Task<IEnumerable<Publication>> GetPublicationsByUserAsync(Guid userId);
}