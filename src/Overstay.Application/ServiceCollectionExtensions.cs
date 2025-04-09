using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Overstay.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .Enrich.FromLogContext()
            .MinimumLevel.Debug()
            .CreateLogger();
        
        return services;
    }
}