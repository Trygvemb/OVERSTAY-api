using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Overstay.Application.Commons.Errors;
using Overstay.Domain.Entities;
using Overstay.Infrastructure.Data.Identities;

namespace Overstay.Infrastructure.Data.Seeds;

public static class IdentitySeed
{
    private static readonly Guid AdminUserId = new("00000000-1000-0000-0000-000000000001");
    private static readonly Guid RegularUserId = new("00000000-1000-0000-0000-000000000002");
    private static readonly Guid AdminRoleId = new("00000000-1000-0000-0000-000000000003");
    private static readonly Guid UserRoleId = new("00000000-1000-0000-0000-000000000004");

    // UK and US country IDs from your seed data
    private static readonly Guid UkCountryId = new("00000000-0000-0000-0000-000000000183");
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
                    Id = AdminRoleId,
                    Name = RoleTypeConstants.Admin,
                    NormalizedName = RoleTypeConstants.Admin.ToUpper(),
                    ConcurrencyStamp = "00000000-0000-0000-0000-000000000001", // Fixed value
                },
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
        // Password: Admin123!
        var adminPasswordHash =
            "AQAAAAIAAYagAAAAENfB6BxN/Z1wQz9vgEiJAL6xxWWlHfgK8JQkZ3XvjLlrqzYb6ASzjOYNkI/6OYvVeA==";

        // Password: User123!
        var userPasswordHash =
            "AQAAAAIAAYagAAAAEKK+8C5hcOKF5+HGekX1xHVdO/X8Wm1jlTeCMJLOhst9B4t1xUQZlniUiMCrzG5IXg==";

        var adminUser = new ApplicationUser
        {
            Id = AdminUserId,
            UserName = "admin@example.com",
            NormalizedUserName = "ADMIN@EXAMPLE.COM",
            Email = "admin@example.com",
            NormalizedEmail = "ADMIN@EXAMPLE.COM",
            EmailConfirmed = true,
            SecurityStamp = "ADMIN-SECURITY-STAMP", // Fixed value
            ConcurrencyStamp = "ADMIN-CONCURRENCY-STAMP", // Fixed value
            PasswordHash = adminPasswordHash,
        };

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

        modelBuilder.Entity<ApplicationUser>().HasData(adminUser, regularUser);

        // Seed domain users with static timestamps
        modelBuilder
            .Entity<User>()
            .HasData(
                new
                {
                    Id = AdminUserId,
                    CountryId = UkCountryId,
                    CreatedAt = SeedTimestamp,
                    UpdatedAt = SeedTimestamp,
                },
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
            .HasData(
                new IdentityUserRole<Guid> { UserId = AdminUserId, RoleId = AdminRoleId },
                new IdentityUserRole<Guid> { UserId = RegularUserId, RoleId = UserRoleId },
                // Admin also has User role
                new IdentityUserRole<Guid> { UserId = AdminUserId, RoleId = UserRoleId }
            );
    }
}
