using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Overstay.Application.Services;
using Overstay.Infrastructure.Configurations;
using Overstay.Infrastructure.Data.DbContexts;
using Overstay.Infrastructure.Data.Identities;
using Overstay.Infrastructure.Services;

namespace Overstay.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var dbOptions = DatabaseOptions.Load(configuration);

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                dbOptions.ConnectionString,
                mysqlOptions =>
                {
                    mysqlOptions.MigrationsAssembly("Overstay.Infrastructure");
                    mysqlOptions.EnableRetryOnFailure();
                    mysqlOptions.CommandTimeout(60);
                }
            )
        );

        services
            .AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = true;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            configuration["JwtSettings:SecretKey"]
                                ?? throw new InvalidOperationException()
                        )
                    ),
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                        return Task.CompletedTask;
                    },
                    OnMessageReceived = context =>
                    {
                        Console.WriteLine(
                            $"Token received: {context.Token?[..Math.Min(20, context.Token?.Length ?? 0)]}..."
                        );
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine(
                            $"Token validated for: {context.Principal?.Identity?.Name}"
                        );
                        return Task.CompletedTask;
                    },
                };
            });

        services
            .AddAuthorizationBuilder()
            .AddPolicy(
                "SameUserOrAdmin",
                policy => policy.Requirements.Add(new SameUserOrAdminRequirement())
            );
        services.AddScoped<IAuthorizationHandler, SameUserOrAdminHandler>();
        services.AddScoped<IVisaTypeService, VisaTypeService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
