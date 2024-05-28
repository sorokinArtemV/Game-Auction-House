using System.Text.Json.Serialization;
using SearchService.Data;
using SearchService.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddHttpClient<AuctionServiceHttpClient>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

app.UseAuthorization();

app.MapControllers();

try
{
 await DbInitializer.InitDb(app);
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

app.Run();

