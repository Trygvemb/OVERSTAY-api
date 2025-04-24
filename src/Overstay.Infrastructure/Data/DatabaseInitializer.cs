using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Overstay.Application.Commons.Constants;
using Overstay.Infrastructure.Data.DbContexts;
using Overstay.Infrastructure.Data.Identities;

namespace Overstay.Infrastructure.Data;

public static class DatabaseInitializer
{
    public static async Task InitializeDatabaseAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<ApplicationDbContext>>();
        var context = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        try
        {
            logger.LogInformation("Migrating database...");
            await context.Database.MigrateAsync();

            // These methods will check if data exists and seed if necessary
            await EnsureRolesExistAsync(roleManager);
            await EnsureUsersExistAsync(userManager, context);

            logger.LogInformation("Database initialization completed successfully");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initializing the database");
        }
    }

    private static async Task EnsureRolesExistAsync(RoleManager<IdentityRole<Guid>> roleManager)
    {
        string[] roles = [RoleTypeConstants.Admin, RoleTypeConstants.User];

        foreach (var roleName in roles)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
            }
        }
    }

    private static async Task EnsureUsersExistAsync(
        UserManager<ApplicationUser> userManager,
        ApplicationDbContext context
    )
    {
        if (await userManager.FindByEmailAsync("admin@example.com") is null)
        {
            var ukCountryId = new Guid("00000000-0000-0000-0000-000000000183");
            var admin = new ApplicationUser
            {
                UserName = "admin@example.com",
                Email = "admin@example.com",
                EmailConfirmed = true,
            };

            await userManager.CreateAsync(admin, "Admin123!");
            await userManager.AddToRolesAsync(
                admin,
                [RoleTypeConstants.Admin, RoleTypeConstants.User]
            );

            var user = new User(ukCountryId) { Id = admin.Id };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
