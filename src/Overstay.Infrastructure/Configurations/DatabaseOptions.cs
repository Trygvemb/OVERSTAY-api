using Microsoft.Extensions.Configuration;

namespace Overstay.Infrastructure.Configurations;

public class DatabaseOptions
{
    public string ConnectionString { get; init; } = string.Empty;

    public static DatabaseOptions Load(IConfiguration configuration)
    {
        return new DatabaseOptions
        {
            ConnectionString =
                configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' not found."
                ),
        };
    }
}
