using RepositoryBNTU.API.DTOs.PublicationDTOs;

namespace RepositoryBNTU.API.DTOs.UserDTOs;

public record UserCreateViewModel(string Email, string Password, string Role, List<string> Publications);