namespace RepositoryBNTU.API.DTOs.AuthorDTOs;

public record AuthorUpdateViewModel(Guid Id, string FirstName, string LastName, DateTime DateOfBirth);