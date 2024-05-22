namespace GameItems.Infrastructure.Data.Seeders;

public interface IItemsSeeder
{
    Task Seed<T>(string filePath) where T : class;
}