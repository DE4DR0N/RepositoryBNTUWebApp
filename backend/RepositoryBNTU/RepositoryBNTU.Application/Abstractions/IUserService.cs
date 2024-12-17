using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Application.Abstractions;

public interface IUserService : IGenericService<User>
{
    public Task<User?> GetByEmailAsync(string email);
    public Task<IEnumerable<Publication>> GetPublicationsByUserAsync(Guid userId);
}