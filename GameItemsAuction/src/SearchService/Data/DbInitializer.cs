using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Entities;

namespace SearchService.Data;

public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        await DB.InitAsync("SearchDb",
            MongoClientSettings.FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));


        await DB.Index<Weapon>()
            .Key(x => x.ItemDetails, KeyType.Text)
            .Key(x => x.ItemDetails!.Name, KeyType.Text)
            .Key(x => x.ItemDetails!.ItemLevel, KeyType.Text)
            .Key(x => x.ItemDetails!.RequiredLevel, KeyType.Text)
            .CreateAsync();

        await DB.Index<Armor>()
            .Key(x => x.ItemDetails!.ArmorType, KeyType.Text)
            .Key(x => x.ItemDetails!.Name, KeyType.Text)
            .Key(x => x.ItemDetails!.ItemLevel, KeyType.Text)
            .Key(x => x.ItemDetails!.RequiredLevel, KeyType.Text)
            .CreateAsync();

        var count = await DB.CountAsync<Item>();

        if (count == 0) Console.WriteLine("No data in DB");

        var itemData = await File.ReadAllTextAsync("Data/auctions.json");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var items = JsonSerializer.Deserialize<List<Item>>(itemData, options);

        await DB.SaveAsync(items!);
    }
}

var items = JsonSerializer.Deserialize<List<Item>>(itemData, options);
foreach (var item in items)
{
    if (/* Check if it's an armor item */)
    {
        item.ItemType = "Armor";
    }
    else if (/* Check if it's a weapon item */)
    {
        item.ItemType = "Weapon";
    }
}

var armorItems = items.Where(i => i.ItemType == "Armor").ToList();