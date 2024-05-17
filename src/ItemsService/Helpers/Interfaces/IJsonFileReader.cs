using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;

namespace ItemsService.Helpers;

public interface IJsonFileReader
{
    void ReadAndSave<T>(string filePath, ItemsDbContext context) where T : class;
}