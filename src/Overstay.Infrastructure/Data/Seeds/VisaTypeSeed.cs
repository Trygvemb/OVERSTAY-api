using Microsoft.EntityFrameworkCore;
using Overstay.Domain.Entities.Visas;

namespace Overstay.Infrastructure.Data.Seeds;

public static class VisaTypeSeed
{
    /// <summary>
    /// Seeds the initial set of visa types into the database.
    /// </summary>
    /// <param name="modelBuilder"></param>
    /// <param name="visaTypes"></param>
    /// The <see cref="ModelBuilder"/> used to configure the entity framework model and seed data.
    public static void SeedVisaTypes(ModelBuilder modelBuilder, DbSet<VisaType> visaTypes)
    {
        if (visaTypes.Any())
            return;

        modelBuilder
            .Entity<VisaType>()
            .HasData(
                new VisaType
                {
                    Id = new Guid("10000000-0000-0000-0000-000000000001"),
                    Name = "Test Tourist Visa",
                    Description = "For leisure travel and tourism purposes",
                    DurationInDays = 90,
                    IsMultipleEntry = false,
                },
                new VisaType
                {
                    Id = new Guid("10000000-0000-0000-0000-000000000002"),
                    Name = "Test Business Visa",
                    Description = "For business meetings and commercial activities",
                    DurationInDays = 180,
                    IsMultipleEntry = true,
                },
                new VisaType
                {
                    Id = new Guid("10000000-0000-0000-0000-000000000003"),
                    Name = "Test Student Visa",
                    Description = "For full-time students enrolled in educational institutions",
                    DurationInDays = 365,
                    IsMultipleEntry = true,
                },
                new VisaType
                {
                    Id = new Guid("10000000-0000-0000-0000-000000000004"),
                    Name = "Test Work Visa",
                    Description = "For employment purposes",
                    DurationInDays = 365,
                    IsMultipleEntry = true,
                },
                new VisaType
                {
                    Id = new Guid("10000000-0000-0000-0000-000000000005"),
                    Name = "Test Transit Visa",
                    Description = "For passing through a country to reach another destination",
                    DurationInDays = 7,
                    IsMultipleEntry = false,
                },
                new VisaType
                {
                    Id = new Guid("10000000-0000-0000-0000-000000000006"),
                    Name = "Test Diplomatic Visa",
                    Description = "For diplomatic and official government visits",
                    DurationInDays = 180,
                    IsMultipleEntry = true,
                }
            );
    }
}
