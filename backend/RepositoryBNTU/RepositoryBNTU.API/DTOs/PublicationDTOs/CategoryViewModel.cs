using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.API.DTOs.PublicationDTOs;

public record CategoryViewModel(Guid id, string Name, List<Publication> Publications);