using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Domain.Abstractions;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User> GetByUsernameAsync(string username);
    public Task<User> GetByEmailAsync(string email);
    public Task<IEnumerable<Publication>> GetPublicationsByUserAsync(Guid userId);
}