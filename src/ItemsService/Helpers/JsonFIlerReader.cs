using ItemsService.Helpers.Interfaces;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;
using Newtonsoft.Json;

namespace ItemsService.Helpers;

public class JsonFileReader : IJsonFileReader
{
    public void ReadAndSave<T>(string filePath, ItemsDbContext context) where T : class
    {
        var jsonContent = File.ReadAllText(filePath);

        var items = JsonConvert.DeserializeObject<List<T>>(jsonContent)!;

        if (items == null || items.Count == 0) return;

        foreach (var item in items) context.Set<T>().Add(item);

        context.SaveChanges();
    }
}