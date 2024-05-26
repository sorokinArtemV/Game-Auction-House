using AuctionService.Data;
using AuctionService.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddServices(builder);

var app = builder.Build();

// app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
}

app.UseAuthorization();

app.MapControllers();

try
{
    DbInitializer.InitDb(app);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

app.Run();