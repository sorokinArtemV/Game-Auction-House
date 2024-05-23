using GameItems.Infrastructure.Data.DatabaseContext;
using GameItems.Infrastructure.Helpers.Interfaces;
using Newtonsoft.Json;

namespace GameItems.Infrastructure.Helpers;

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