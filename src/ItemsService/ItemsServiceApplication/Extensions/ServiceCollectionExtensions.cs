using ItemsService.ItemsServiceApplication.Weapons;

namespace ItemsService.ItemsServiceApplication.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IWeaponsService, WeaponsService>();
        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
    }
}