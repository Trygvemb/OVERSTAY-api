using System.Reflection;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Overstay.Application.Commons.Configurations;

namespace Overstay.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );

        MappingConfigurations.Configure();

        services.AddSingleton(TypeAdapterConfig.GlobalSettings);
        services.AddScoped<IMapper, Mapper>();

        return services;
    }
}
