using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Overstay.Domain.Entities;

namespace Overstay.Infrastructure.Data.Seeds;

public static class VisaTypeSeed
{
    // Extract constant prefixes for better readability
    private const string VisaTypeIdPrefix = "10000000-0000-0000-0000-0000000000";

    /// <summary>
    /// Seeds the initial set of visa types into the database.
    /// </summary>
    /// <param name="modelBuilder">The ModelBuilder used to configure the entity framework model and seed data.</param>
    /// <param name="visaTypes">The DbSet of visa types to check if seeding is needed.</param>
    public static void SeedVisaTypes(ModelBuilder modelBuilder, DbSet<VisaType> visaTypes)
    {
        modelBuilder.Entity<VisaType>().HasData(GetPredefinedVisaTypes());
    }

    /// <summary>
    /// Returns a collection of predefined visa types for seeding.
    /// </summary>
    private static IEnumerable<VisaType> GetPredefinedVisaTypes()
    {
        return new[]
        {
            new VisaType("Test Tourist Visa", "For leisure travel and tourism purposes", 90, false)
            {
                Id = new Guid($"{VisaTypeIdPrefix}01"),
            },
            new VisaType(
                "Test Business Visa",
                "For business meetings and commercial activities",
                180,
                true
            )
            {
                Id = new Guid($"{VisaTypeIdPrefix}02"),
            },
            new VisaType(
                "Test Student Visa",
                "For full-time students enrolled in educational institutions",
                365,
                true
            )
            {
                Id = new Guid($"{VisaTypeIdPrefix}03"),
            },
            new VisaType("Test Work Visa", "For employment purposes", 365, true)
            {
                Id = new Guid($"{VisaTypeIdPrefix}04"),
            },
            new VisaType(
                "Test Transit Visa",
                "For passing through a country to reach another destination",
                7,
                false
            )
            {
                Id = new Guid($"{VisaTypeIdPrefix}05"),
            },
            new VisaType(
                "Test Diplomatic Visa",
                "For diplomatic and official government visits",
                180,
                true
            )
            {
                Id = new Guid($"{VisaTypeIdPrefix}06"),
            },
        };
    }
}
