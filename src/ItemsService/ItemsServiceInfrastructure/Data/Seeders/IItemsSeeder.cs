namespace ItemsService.ItemsServiceInfrastructure.Data.Seeders;

public interface IItemsSeeder
{
    Task Seed<T>() where T : class;
}