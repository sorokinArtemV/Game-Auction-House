using AuctionService.Data;
using AuctionService.Interfaces;
using AuctionService.Middleware;
using AuctionService.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SearchService.Consumers;

namespace AuctionService.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddValidatorsFromAssembly(applicationAssembly)
            .AddFluentValidationAutoValidation();


        services.AddScoped<IAuctionsService, AuctionsService>();

        services.AddHttpClient();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddMassTransit(x =>
        {
            
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });

        services.AddScoped<ErrorHandlingMiddleware>();

        services.AddDbContext<AuctionDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
    }
}