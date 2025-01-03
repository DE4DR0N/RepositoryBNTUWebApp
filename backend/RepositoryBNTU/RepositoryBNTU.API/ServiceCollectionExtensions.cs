﻿using Microsoft.EntityFrameworkCore;
using RepositoryBNTU.API.Mappings;
using RepositoryBNTU.Application.Abstractions;
using RepositoryBNTU.Application.Services;
using RepositoryBNTU.Domain.Abstractions;
using RepositoryBNTU.Persistence;
using RepositoryBNTU.Persistence.Repositories;

namespace RepositoryBNTU.API;

public static class ServiceCollectionExtensions
{
    public static void AddProjectServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(
            typeof(AuthorMappingProfile),
            typeof(CategoryMappingProfile),
            typeof(PublicationMappingProfile),
            typeof(UserMappingProfile));
        
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IPublicationRepository, PublicationRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IPublicationService, PublicationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<TokenService>();

        services.AddDbContext<RepositoryDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
}
