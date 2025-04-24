using Microsoft.AspNetCore.Identity;
using Overstay.Application.Commons.Constants;
using Overstay.Infrastructure.Data.Identities;

namespace Overstay.Infrastructure.Data.Seeds;

public static class IdentitySeed
{
    private static readonly Guid RegularUserId = new("00000000-1000-0000-0000-000000000002");
    private static readonly Guid UserRoleId = new("00000000-1000-0000-0000-000000000004");

    // UK and US country IDs from your seed data
    private static readonly Guid UsCountryId = new("00000000-0000-0000-0000-000000000184");

    // Static timestamp for seed data
    private static readonly DateTime SeedTimestamp = new DateTime(
        2023,
        1,
        1,
        0,
        0,
        0,
        DateTimeKind.Utc
    );

    /// <summary>
    /// Seeds the initial roles for the application.
    /// </summary>
    public static void SeedRoles(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<IdentityRole<Guid>>()
            .HasData(
                new IdentityRole<Guid>
                {
                    Id = UserRoleId,
                    Name = RoleTypeConstants.User,
                    NormalizedName = RoleTypeConstants.User.ToUpper(),
                    ConcurrencyStamp = "00000000-0000-0000-0000-000000000002", // Fixed value
                }
            );
    }

    /// <summary>
    /// Seeds test users for the application with pre-defined password hashes.
    /// </summary>
    public static void SeedUsers(ModelBuilder modelBuilder)
    {
        // Create application users with hard-coded password hashes
        // Note: These password hashes are for development only

        // Password: User123!
        var userPasswordHash =
            "AQAAAAIAAYagAAAAEKK+8C5hcOKF5+HGekX1xHVdO/X8Wm1jlTeCMJLOhst9B4t1xUQZlniUiMCrzG5IXg==";

        var regularUser = new ApplicationUser
        {
            Id = RegularUserId,
            UserName = "user@example.com",
            NormalizedUserName = "USER@EXAMPLE.COM",
            Email = "user@example.com",
            NormalizedEmail = "USER@EXAMPLE.COM",
            EmailConfirmed = true,
            SecurityStamp = "USER-SECURITY-STAMP", // Fixed value
            ConcurrencyStamp = "USER-CONCURRENCY-STAMP", // Fixed value
            PasswordHash = userPasswordHash,
        };

        modelBuilder.Entity<ApplicationUser>().HasData(regularUser);

        // Seed domain users with static timestamps
        modelBuilder
            .Entity<User>()
            .HasData(
                new
                {
                    Id = RegularUserId,
                    CountryId = UsCountryId,
                    CreatedAt = SeedTimestamp,
                    UpdatedAt = SeedTimestamp,
                }
            );
    }

    /// <summary>
    /// Seeds the user role assignments.
    /// </summary>
    public static void SeedUserRoles(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<IdentityUserRole<Guid>>()
            .HasData(new IdentityUserRole<Guid> { UserId = RegularUserId, RoleId = UserRoleId });
    }
}
