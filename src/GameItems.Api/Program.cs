using GameItems.Application.Extensions;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Infrastructure.Data.DatabaseContext;
using GameItems.Infrastructure.Data.Seeders;
using GameItems.Infrastructure.Extensions;
using GameItems.Infrastructure.Helpers;
using ItemsService.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, loggerConfig) =>
{
    loggerConfig
        .ReadFrom.Configuration(context.Configuration) // IConfig - appsettings.json
        .ReadFrom.Services(services); // services collection
});

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddApplication();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ItemsDbContext>();
    var itemsSeeder = new ItemsSeeder(context, new JsonFileReader());
    await itemsSeeder.Seed<Weapon>(Path.Combine(
        @"C:\Users\artem\OneDrive\Desktop\Sharp\ASP-Projects\GameItemsApi\src\GameItems.Infrastructure\Data\Seeders\SeedingData",
        "WeaponsSeeder.json"));

    await itemsSeeder.Seed<Armor>(Path.Combine(
        @"C:\Users\artem\OneDrive\Desktop\Sharp\ASP-Projects\GameItemsApi\src\GameItems.Infrastructure\Data\Seeders\SeedingData",
        "ArmorsSeeder.json"));
}
catch (Exception e)
{
    Console.WriteLine("Insertion of data failed. Error: " + e);
    throw;
}


app.Run();