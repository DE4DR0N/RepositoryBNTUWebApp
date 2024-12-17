using RepositoryBNTU.API.DTOs.PublicationDTOs;

namespace RepositoryBNTU.API.DTOs.UserDTOs;

public record UserViewModel(Guid Id, string Email, string Password, string Role, List<PublicationViewModel> Publications);