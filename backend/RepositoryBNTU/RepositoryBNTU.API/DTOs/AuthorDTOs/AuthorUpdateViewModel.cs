namespace RepositoryBNTU.API.DTOs.AuthorDTOs;

public record AuthorUpdateViewModel(Guid Id, string FirstName, string LastName, DateOnly DateOfBirth);