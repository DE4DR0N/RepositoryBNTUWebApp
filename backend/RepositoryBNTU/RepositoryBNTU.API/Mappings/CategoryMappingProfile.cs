using AutoMapper;
using RepositoryBNTU.API.DTOs.CategoryDTOs;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.API.Mappings;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<CategoryCreateViewModel, Category>();
        CreateMap<CategoryUpdateViewModel, Category>();
        CreateMap<Category, CategoryViewModel>();
    }
}