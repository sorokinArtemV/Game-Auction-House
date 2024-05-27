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

        // Create a common index for both armor and weapon items
        await DB.Index<Item>()
            .Key(x => x.ItemDetails!.Name, KeyType.Text)
            .Key(x => x.ItemDetails!.ItemLevel, KeyType.Text)
            .Key(x => x.ItemDetails!.RequiredLevel, KeyType.Text)
            .Key(x => x.ItemDetails!.WeaponType, KeyType.Text)
            .Key(x => x.ItemDetails!.ArmorType, KeyType.Text)
            .Key(x => x.ItemDetails!.Quality, KeyType.Text)
            .CreateAsync();

        var count = await DB.CountAsync<Item>();

        if (count == 0) Console.WriteLine("No data in DB");

        // Deserialize based on item type
        var itemData = await File.ReadAllTextAsync("Data/auctions.json");
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var items = JsonSerializer.Deserialize<List<Item>>(itemData, options);


        await DB.SaveAsync(items);
    }
}

/*
public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        await DB.InitAsync("SearchDb",
            MongoClientSettings.FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

        await DB.Index<Weapon>()
            .Key(x => x.ItemDetails.WeaponType, KeyType.Text)
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

        // Deserialize based on item type
        var itemData = await File.ReadAllTextAsync("Data/auctions.json");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        List<Armor> armors = [];
        List<Weapon> weapons = [];

        using (JsonDocument doc = JsonDocument.Parse(itemData))
        {
            foreach (var element in doc.RootElement.EnumerateArray())
            {
                var itemType = element.GetProperty("itemDetails").GetProperty("itemType").GetString();

                switch (itemType)
                {
                    case "armor":
                    {
                        var armor = JsonSerializer.Deserialize<Armor>(element.GetRawText(), options);
                        armors.Add(armor);
                        break;
                    }
                    case "weapon":
                    {
                        var weapon = JsonSerializer.Deserialize<Weapon>(element.GetRawText(), options);
                        weapons.Add(weapon);
                        break;
                    }
                }
            }
        }

        await DB.SaveAsync(weapons);
        await DB.SaveAsync(armors);
    }
}
*/