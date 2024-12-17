namespace RepositoryBNTU.API.DTOs.PublicationDTOs;

public record PublicationUpdateViewModel(
    Guid Id,
    string Title,
    string Description,
    string ISBN,
    DateOnly PublishDate,
    string Author,
    string Category);