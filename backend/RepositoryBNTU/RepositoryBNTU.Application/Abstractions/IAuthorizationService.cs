using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.Application.Abstractions;

public interface IAuthorizationService
{
    Task RegisterAsync(User entity);
    Task<string> LoginAsync(User entity);
    Task LogoutAsync();
    //Task<User> RefreshAsync();
}