using ItemsService.Helpers;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemsServiceApplication.Extensions;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;
using ItemsService.ItemsServiceInfrastructure.Data.Seeders;
using ItemsService.ItemsServiceInfrastructure.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, loggerConfig) =>
{
    loggerConfig
        .ReadFrom.Configuration(context.Configuration) // IConfig - appsettings.json
        .ReadFrom.Services(services); // services collection
});

builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddApplication();

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ItemsDbContext>();
    var itemsSeeder = new ItemsSeeder(context, new JsonFileReader());
    await itemsSeeder.Seed<Weapon>("WeaponsSeeder.json");
    await itemsSeeder.Seed<Armor>("ArmorSeeder.json");
}
catch (Exception e)
{
    Console.WriteLine("Insertion of data failed. Error: " +  e);
    throw;
}


app.Run();