using System.Reflection;
using System.Reflection.Metadata;
using FluentValidation;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Overstay.Application.Commons.Behaviors;
using Overstay.Application.Commons.Configurations;

namespace Overstay.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(
            Assembly.GetExecutingAssembly(),
            includeInternalTypes: true
        );

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        MappingConfigurations.Configure();

        services.AddSingleton(TypeAdapterConfig.GlobalSettings);
        services.AddScoped<IMapper, Mapper>();

        return services;
    }
}
