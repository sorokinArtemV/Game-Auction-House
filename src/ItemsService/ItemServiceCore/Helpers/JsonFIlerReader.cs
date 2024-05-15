using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;
using Newtonsoft.Json;

namespace ItemsService.ItemServiceCore.Helpers;

public class JsonFileReader
{
    public void ReadAndSave<T>(string filePath, ItemsDbContext context) where T : class
    {
        string jsonContent = File.ReadAllText(filePath);

        List<T> items = JsonConvert.DeserializeObject<List<T>>(jsonContent)!;

        if (items == null || items.Count == 0) return;

        foreach (var item in items)
        {
            context.Set<T>().Add(item);
        }

        context.SaveChanges();
    }
}