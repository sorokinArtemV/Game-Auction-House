using ItemsService.Helpers;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;
using ItemsService.ItemsServiceInfrastructure.Data.Seeders;
using ItemsService.ItemsServiceInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ItemsService.ItemsServiceInfrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddScoped<IItemsSeeder, ItemsSeeder>();
        services.AddScoped<JsonFileReader>();
        
        services.AddScoped<IItemsSeeder, ItemsSeeder>();
        services.AddScoped<IGenericRepository<Weapon>, WeaponsRepository>();
        services.AddTransient<JsonFileReader>();
        
        services.AddDbContext<ItemsDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
    }
}