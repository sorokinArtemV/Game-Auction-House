using GameItems.Core.Entities.ItemParameters;
using GameItems.Core.Entities.ItemTypes;
using GameItems.Core.RepositoryContracts;
using GameItems.Infrastructure.Data.DatabaseContext;
using GameItems.Infrastructure.Helpers;
using GameItems.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameItems.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
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