using ItemsService.Helpers;
using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;
using ItemsService.ItemsServiceInfrastructure.Data.Seeders;
using ItemsService.ItemsServiceInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ItemsService.ItemsServiceInfrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IItemsSeeder, ItemsSeeder>();
        services.AddScoped<IGenericItemsRepository<Weapon>, WeaponsItemsRepository>();
        services.AddScoped<IGenericItemsRepository<Armor>, ArmorsItemsRepository>();
        services.AddScoped<IGenericEffectsRepository<WeaponEffect>, WeaponEffectsItemsRepository>();
        services.AddScoped<IGenericEffectsRepository<ArmorEffect>, ArmorsEffectsItemsRepository>();
        services.AddTransient<JsonFileReader>();

        services.AddDbContext<ItemsDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
    }
}