using ItemsService.ItemServiceCore.Entities.ItemParameters;

namespace ItemsService.ItemServiceCore.RepositoryContracts;

public interface IGenericEffectsRepository<in T> where T : BaseEffect
{
    public Task<int> CreateAsync(T entity);
    public Task DeleteAsync(T entity);
    public Task DeleteAllAsync(IEnumerable<T> entities);
    public Task SaveChangesAsync();
}