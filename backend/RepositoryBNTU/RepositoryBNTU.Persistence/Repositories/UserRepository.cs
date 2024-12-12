using Microsoft.EntityFrameworkCore;
using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Persistence.Repositories;

public class UserRepository(RepositoryDbContext context) : IUserRepository
{
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await context.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(User entity)
    {
        await context.Users.AddAsync(entity);
    }

    public void Update(User entity)
    {
        context.Users.Update(entity);
    }

    public void Delete(User entity)
    {
        context.Users.Remove(entity);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IEnumerable<Publication>> GetPublicationsByUserAsync(Guid userId)
    {
        var user = await context.Users
            .AsNoTracking()
            .Include(u => u.FavoritePublications)
            .FirstOrDefaultAsync(u => u.Id == userId);
        
        return user?.FavoritePublications.ToList() ?? new List<Publication>();
    }
}