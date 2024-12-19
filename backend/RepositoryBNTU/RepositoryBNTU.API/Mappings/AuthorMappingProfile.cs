using AutoMapper;
using RepositoryBNTU.API.DTOs.AuthorDTOs;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.API.Mappings;

public class AuthorMappingProfile : Profile
{
    public AuthorMappingProfile()
    {
        CreateMap<AuthorCreateViewModel, Author>();
        CreateMap<AuthorUpdateViewModel, Author>();
        CreateMap<Author, AuthorViewModel>();
    }
}