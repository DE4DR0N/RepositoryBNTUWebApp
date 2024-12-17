namespace RepositoryBNTU.API.DTOs.AuthorDTOs;

public record AuthorCreateViewModel(
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    List<string> Publications);