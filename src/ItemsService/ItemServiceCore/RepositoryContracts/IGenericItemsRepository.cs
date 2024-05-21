using ItemsService.ItemServiceCore.Entities;
using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;

namespace ItemsService.ItemServiceCore.RepositoryContracts;

public interface IGenericItemsRepository<T> where T : BaseItem
{
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<IEnumerable<T>> GetAllMatchingAsync(string? searchPhrase);
    public Task<T?> GetByIdAsync(int id);
    public Task<int> CreateAsync(T entity);
    public Task DeleteAsync(T entity);
    public Task SaveChangesAsync();
}