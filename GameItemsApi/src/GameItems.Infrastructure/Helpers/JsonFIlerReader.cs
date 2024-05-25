using GameItems.Infrastructure.Data.DatabaseContext;
using Newtonsoft.Json;

namespace GameItems.Infrastructure.Helpers;

public class JsonFileReader : IJsonFileReader
{
    public List<T> Read<T>(string filePath) where T : class
    {
        var jsonContent = File.ReadAllText(filePath);

        var items = JsonConvert.DeserializeObject<List<T>>(jsonContent);

        if (items == null || items.Count == 0) throw new Exception("Json file is empty");

        return items;
    }
}