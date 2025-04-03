using Microsoft.EntityFrameworkCore;
using Overstay.Infrastructure.Configurations;
using Overstay.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

#region Data Access Layer
var dbOptions = builder.Configuration.GetSection(nameof(DatabaseOptions)).Get<DatabaseOptions>();
var dbConnectionString = dbOptions?.ConnectionString;

builder.Services.AddDataAccessLayer(dbConnectionString!);
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
