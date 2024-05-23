using GameItems.Core.Entities.ItemTypes;
using GameItems.Infrastructure.Data.DatabaseContext;
using GameItems.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace ItemsService.Seeders;

public class DbInitializer : IDbInitializer
{
    private readonly JsonFileReader _jsonFileReader;

    public DbInitializer(JsonFileReader jsonFileReader)
    {
        _jsonFileReader = jsonFileReader;
    }

    public void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetRequiredService<ItemsDbContext>());
    }

    private void SeedData(ItemsDbContext context)
    {
        context.Database.Migrate();

        if (context.Weapons.Any() || context.Armors.Any())
        {
            Console.WriteLine("Database is already seeded");
            return;
        }

        var weapons = _jsonFileReader.Read<Weapon>(
            @"C:\Users\artem\OneDrive\Desktop\Sharp\ASP-Projects\GameItemsAuction\GameItemsApi\src\GameItems.Api\Seeders\SeedingData\WeaponsSeeder.json");
        var armors = _jsonFileReader.Read<Armor>(
            @"C:\Users\artem\OneDrive\Desktop\Sharp\ASP-Projects\GameItemsAuction\GameItemsApi\src\GameItems.Api\Seeders\SeedingData\ArmorsSeeder.json");


        context.Weapons.AddRange(weapons);
        context.Armors.AddRange(armors);

        context.SaveChanges();
    }
}