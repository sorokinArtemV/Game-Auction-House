using ItemsService.Helpers;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;

namespace ItemsService.ItemsServiceInfrastructure.Data.Seeders;

public class ItemsSeeder : IItemsSeeder
{
    private readonly ItemsDbContext _dbContext;
    private readonly JsonFileReader _jsonFileReader;

    public ItemsSeeder(ItemsDbContext dbContext, JsonFileReader jsonFileReader)
    {
        _dbContext = dbContext;
        _jsonFileReader = jsonFileReader;
    }

    public async Task Seed<T>(string filePath) where T : class
    {
        if (await _dbContext.Database.CanConnectAsync())
            if (!_dbContext.Set<T>().Any())
                _jsonFileReader.ReadAndSave<T>(filePath, _dbContext);
    }
}