using AutoMapper;
using RepositoryBNTU.API.DTOs.AuthorizationDTOs;
using RepositoryBNTU.API.DTOs.UserDTOs;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.API.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserCreateViewModel, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
        CreateMap<UserUpdateViewModel, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
        CreateMap<User, UserViewModel>();
        CreateMap<AuthorizationViewModel, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
    }
}