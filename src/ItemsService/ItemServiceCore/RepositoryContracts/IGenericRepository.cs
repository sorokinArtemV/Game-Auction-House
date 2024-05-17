using ItemsService.ItemServiceCore.Entities.ItemTypes;

namespace ItemsService.ItemServiceCore.RepositoryContracts;

public interface IGenericRepository<T> where T : BaseItem
{
    public  Task<IEnumerable<T>> GetAllAsync();
    public Task<T?> GetByIdAsync(int id);
    public Task<int> CreateAsync(T entity);
}