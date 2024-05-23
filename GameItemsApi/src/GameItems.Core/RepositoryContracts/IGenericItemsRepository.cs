using GameItems.Core.Constants;
using GameItems.Core.Entities.ItemTypes;

namespace GameItems.Core.RepositoryContracts;

public interface IGenericItemsRepository<T> where T : BaseItem
{
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<(IEnumerable<T>, int)> GetAllMatchingAsync(
        string? searchPhrase, 
        int pageNumber, 
        int pageSize,
        string? sortBy,
        SortDirection sortDirection);
    public Task<T?> GetByIdAsync(int id);
    public Task<int> CreateAsync(T entity);
    public Task DeleteAsync(T entity);
    public Task SaveChangesAsync();
}