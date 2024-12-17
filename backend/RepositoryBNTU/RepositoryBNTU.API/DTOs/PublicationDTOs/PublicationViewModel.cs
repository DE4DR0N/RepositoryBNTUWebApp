using RepositoryBNTU.API.DTOs.AuthorDTOs;

namespace RepositoryBNTU.API.DTOs.PublicationDTOs;

public record PublicationViewModel(
    Guid Id,
    string Title,
    string Description,
    string ISBN,
    DateOnly PublishDate,
    AuthorViewModel Author,
    CategoryViewModel Category);