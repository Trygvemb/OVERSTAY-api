using System.Text.Json.Serialization;
using Overstay.API.Commons;
using Overstay.Application;
using Overstay.Application.Commons.JsonConverters;
using Overstay.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.Converters.Add(new ResultJsonConverter());
        options.JsonSerializerOptions.Converters.Add(new ResultJsonConverterFactory());
    });

builder.Services.AddOpenApi(
    "v1",
    options =>
    {
        options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
    }
);

builder.Services.AddInfrastructureLayer(builder.Configuration).AddApplicationLayer();

builder
    .Logging.ClearProviders()
    .AddConsole()
    .AddDebug()
    .SetMinimumLevel(LogLevel.Information)
    .AddFilter("Microsoft.AspNetCore.Authorization", LogLevel.Debug);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Initialize database with seed data
    //await DatabaseInitializer.InitializeDatabaseAsync(app.Services);

    app.MapOpenApi();
    app.MapScalarApiReference();
}

builder
    .Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile(
        $"appsettings.{builder.Environment.EnvironmentName}.json",
        optional: true,
        reloadOnChange: true
    )
    .AddEnvironmentVariables();

app.UseHttpsRedirection().UseAuthentication().UseAuthorization();

app.MapControllers();

app.Run();
