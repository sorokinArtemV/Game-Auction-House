using ItemsService.ItemServiceCore.Entities;
using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.Entities.ItemTypes;

namespace ItemsService.ItemServiceCore.RepositoryContracts;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<int> CreateAsync(T entity);
    Task DeleteAsync(T entity);
    Task SaveChangesAsync();
}