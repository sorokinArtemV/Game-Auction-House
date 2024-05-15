using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;
using Newtonsoft.Json;

namespace ItemsService.ItemServiceCore.Helpers;

public class JsonFileReader
{
    public void ReadAndSave(string filePath, ItemsDbContext context)
    {
        string jsonContent = File.ReadAllText(filePath);

        List<Weapon> weapons = JsonConvert.DeserializeObject<List<Weapon>>(jsonContent)!;

        if (weapons == null || weapons.Count == 0) return;
        
        foreach (var weapon in weapons)
        {
            context.Weapons.Add(weapon);
        }
        
        context.SaveChanges();
    }
}