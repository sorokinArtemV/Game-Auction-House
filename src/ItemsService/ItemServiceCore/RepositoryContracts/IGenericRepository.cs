using ItemsService.ItemServiceCore.Entities.ItemTypes;

namespace ItemsService.ItemServiceCore.RepositoryContracts;

public interface IGenericRepository<T> where T : BaseItem
{
    public  Task<IEnumerable<T>> GetAllAsync();
}