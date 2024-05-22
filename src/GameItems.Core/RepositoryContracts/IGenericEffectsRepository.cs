using GameItems.Core.Entities.ItemParameters;

namespace GameItems.Core.RepositoryContracts;

public interface IGenericEffectsRepository<in T> where T : BaseEffect
{
    public Task<int> CreateAsync(T entity);
    public Task DeleteAsync(T entity);
    public Task DeleteAllAsync(IEnumerable<T> entities);
    public Task SaveChangesAsync();
}