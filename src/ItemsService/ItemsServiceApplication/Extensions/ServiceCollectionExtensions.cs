using FluentValidation;
using FluentValidation.AspNetCore;
using ItemsService.ItemsServiceApplication.Weapons;

namespace ItemsService.ItemsServiceApplication.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        
        services.AddScoped<IWeaponsService, WeaponsService>();
        
        services.AddAutoMapper(applicationAssembly);
        
        services.AddValidatorsFromAssembly(applicationAssembly)
            .AddFluentValidationAutoValidation();
    }
}