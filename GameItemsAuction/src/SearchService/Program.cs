using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

}

app.UseAuthorization();

app.MapControllers();

await DB.InitAsync("SearchDb",
    MongoClientSettings.FromConnectionString(builder.Configuration.GetConnectionString("MongoDbConnection")));

await DB.Index<Item>()
    .Key(x => x.ItemDetails.)

app.Run();