using RepositoryBNTU.API.DTOs.PublicationDTOs;

namespace RepositoryBNTU.API.DTOs.AuthorDTOs;

public record AuthorViewModel(
    Guid Id,
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    List<PublicationViewModel> Publications);