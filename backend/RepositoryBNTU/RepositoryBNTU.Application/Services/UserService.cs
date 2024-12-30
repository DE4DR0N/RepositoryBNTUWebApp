using RepositoryBNTU.Application.Abstractions;
using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Domain.Entities;
using RepositoryBNTU.Domain.Filters;

namespace RepositoryBNTU.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync(UserFilter filter)
    {
        var users = await _unitOfWork.Users.GetAllAsync(filter);
        return users;
    }

    public async Task CreateAsync(User entity)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(entity.Email);
        if (user != null) throw new Exception("Conflict: User already exists");
        
        entity.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(entity.PasswordHash);
        
        await _unitOfWork.Users.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(User entity)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(entity.Id);
        if (user == null) throw new KeyNotFoundException("User does not exist");
        
        var userToUpdate = await _unitOfWork.Users.GetByEmailAsync(entity.Email);
        if (userToUpdate != null && user.Id != userToUpdate.Id) throw new Exception("Conflict: User already exists");
        
        entity.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(entity.PasswordHash);
        
        _unitOfWork.Users.Update(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User does not exist");
        
        _unitOfWork.Users.Delete(user);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(email);
        return user;
    }

    public async Task<IEnumerable<Publication>> GetPublicationsByUserAsync(Guid userId)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        if (user == null) throw new KeyNotFoundException("User not found");
        
        var publications = await _unitOfWork.Users.GetPublicationsByUserAsync(userId);
        return publications;
    }
}