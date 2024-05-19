﻿using ItemsService.Helpers;
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
        services.AddScoped<IGenericRepository<Weapon>, WeaponsRepository>();
        services.AddScoped<IGenericRepository<Armor>, ArmorsRepository>();
        services.AddScoped<IGenericRepository<WeaponEffect>, WeaponEffectsRepository>();
        services.AddTransient<JsonFileReader>();
        
        services.AddDbContext<ItemsDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
    }
}