namespace RepositoryBNTU.API.DTOs.PublicationDTOs;

public record CategoryUpdateViewModel(Guid Id, string Name, List<string> Publications);