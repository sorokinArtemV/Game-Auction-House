using GameItems.Infrastructure.Data.DatabaseContext;

namespace GameItems.Infrastructure.Helpers.Interfaces;

public interface IJsonFileReader
{
    void ReadAndSave<T>(string filePath, ItemsDbContext context) where T : class;
}