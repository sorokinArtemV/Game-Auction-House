using ItemsService.ItemServiceCore.Entities.ItemParameters;

namespace ItemsService.ItemServiceCore.RepositoryContracts;

public interface IGenericEffectsRepository<T> where T : BaseEffect
{
    public Task<int> CreateAsync(T entity);
}