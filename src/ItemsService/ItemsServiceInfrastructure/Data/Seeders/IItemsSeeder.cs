namespace ItemsService.ItemsServiceInfrastructure.Data.Seeders;

public interface IItemsSeeder
{
    Task Seed<T>(string filePath) where T : class;
}