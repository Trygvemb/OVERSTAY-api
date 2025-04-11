using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Overstay.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssembly(Assembly
                .GetExecutingAssembly()));
        
        return services;
    }
}