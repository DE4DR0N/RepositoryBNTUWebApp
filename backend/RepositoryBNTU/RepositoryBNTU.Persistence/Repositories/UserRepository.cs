using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Persistence.Repositories;

public class UserRepository(RepositoryDbContext context) : IUserRepository
{
    public async Task<User> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public void Update(User entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Publication>> GetPublicationsByUserAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}