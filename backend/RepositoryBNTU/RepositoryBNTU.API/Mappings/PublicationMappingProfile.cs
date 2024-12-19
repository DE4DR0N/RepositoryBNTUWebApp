using AutoMapper;
using RepositoryBNTU.API.DTOs.PublicationDTOs;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.API.Mappings;

public class PublicationMappingProfile : Profile
{
    public PublicationMappingProfile()
    {
        CreateMap<PublicationCreateViewModel, Publication>();
        CreateMap<PublicationUpdateViewModel, Publication>();
        CreateMap<Publication, PublicationViewModel>();
    }
}