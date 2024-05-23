using GameItems.Infrastructure.Data.DatabaseContext;

namespace GameItems.Infrastructure.Helpers;

public interface IJsonFileReader
{
    List<T> Read<T>(string filePath) where T : class;
}