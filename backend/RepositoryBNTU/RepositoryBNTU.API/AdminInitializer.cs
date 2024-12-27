using RepositoryBNTU.Application.Abstractions;
using RepositoryBNTU.Domain.Entities;

namespace RepositoryBNTU.API;

public static class AdminInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        using var scope = serviceProvider.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<IUserService>();

        string adminEmail = configuration["AdminUser:Email"]!;
        string adminPassword = configuration["AdminUser:Password"]!;
        string adminRole = "Admin";

        if (await userManager.GetByEmailAsync(adminEmail) == null)
        {
            var adminUser = new User
            {
                Email = adminEmail, 
                PasswordHash = adminPassword,
                Role = adminRole
            };
            await userManager.CreateAsync(adminUser);
        }
    }
}
