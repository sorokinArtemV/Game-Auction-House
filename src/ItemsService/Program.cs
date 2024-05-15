using ItemsService.ItemServiceCore.Helpers;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ItemsDbContext>();
    JsonFileReader jsonFileReader = new JsonFileReader();
    jsonFileReader.ReadAndSave("ItemsSeeder.json", context);
}

app.Run();