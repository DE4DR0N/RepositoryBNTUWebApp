using RepositoryBNTU.Application.Abstractions;
using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Application.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly TokenService _tokenService;

    public AuthorizationService(IUnitOfWork unitOfWork, TokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
    }

    public async Task RegisterAsync(User entity)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(entity.Email);
        if (user != null) throw new Exception("Conflict User");
        entity.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(entity.PasswordHash);
        entity.Role = "User";

        await _unitOfWork.Users.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<string> LoginAsync(User entity)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(entity.Email);
        if (user == null || !BCrypt.Net.BCrypt.EnhancedVerify(entity.PasswordHash, user.PasswordHash))
        {
            throw new UnauthorizedAccessException("Invalid email or password");
        }
        var accessToken = _tokenService.GenerateToken(user.Email, user.Role);
        
        return accessToken;
    }

    public async Task LogoutAsync()
    {
        throw new NotImplementedException();
    }
}