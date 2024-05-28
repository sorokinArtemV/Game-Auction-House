using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Entities;
using SearchService.Services;

namespace SearchService.Data;

public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        await DB.InitAsync("SearchDb",
            MongoClientSettings.FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

        // Create a common index for both armor and weapon items
        await DB.Index<Item>()
            .Key(x => x.ItemDetails!.Name, KeyType.Text)
            .Key(x => x.ItemDetails!.ItemLevel, KeyType.Text)
            .Key(x => x.ItemDetails!.RequiredLevel, KeyType.Text)
            .Key(x => x.ItemDetails!.WeaponType, KeyType.Text)
            .Key(x => x.ItemDetails!.ArmorType, KeyType.Text)
            .Key(x => x.ItemDetails!.Quality, KeyType.Text)
            .CreateAsync();
        
        using var scope = app.Services.CreateScope();
        
        var httpClient = scope.ServiceProvider.GetRequiredService<AuctionServiceHttpClient>();
        
        var items = await httpClient.GetAllItemsForSearchDb();

        Console.WriteLine(items.Count + "returned from AuctionsService");

        if (items.Count > 0) await DB.SaveAsync(items);

    }
}
