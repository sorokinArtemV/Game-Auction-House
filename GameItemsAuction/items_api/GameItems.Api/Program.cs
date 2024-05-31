using GameItems.Application.Extensions;
using GameItems.Infrastructure.Extensions;
using ItemsService.Middleware;
using ItemsService.Seeders;
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

builder.Services.AddTransient<IDbInitializer, DbInitializer>();

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
    app.Services.GetRequiredService<IDbInitializer>()?.InitDb(app);
}
catch (Exception e)
{
    Console.WriteLine("Insertion of data failed. Error: " + e);
    throw;
}

app.Run();