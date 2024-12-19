namespace RepositoryBNTU.API.DTOs.PublicationDTOs;

public record PublicationCreateViewModel(
    string Title,
    string Description,
    string ISBN,
    DateOnly PublishDate,
    Guid CategoryId,
    Guid AuthorId);