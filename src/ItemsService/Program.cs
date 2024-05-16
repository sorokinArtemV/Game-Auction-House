using ItemsService.Helpers;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;
using ItemsService.ItemsServiceInfrastructure.Data.Seeders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IItemsSeeder, ItemsSeeder>();
builder.Services.AddTransient<JsonFileReader>();

builder.Services.AddControllers();

builder.Services.AddDbContext<ItemsDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

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