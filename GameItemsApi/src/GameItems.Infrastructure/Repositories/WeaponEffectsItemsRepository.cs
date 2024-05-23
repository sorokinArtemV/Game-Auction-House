using GameItems.Core.Entities.ItemParameters;
using GameItems.Core.RepositoryContracts;
using GameItems.Infrastructure.Data.DatabaseContext;

namespace GameItems.Infrastructure.Repositories;

public class WeaponEffectsItemsRepository(ItemsDbContext dbContext) : IGenericEffectsRepository<WeaponEffect>
{
    public async Task<int> CreateAsync(WeaponEffect entity)
    {
        dbContext.Add(entity);

        await dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task DeleteAsync(WeaponEffect entity)
    {
        dbContext.Remove(entity);

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAllAsync(IEnumerable<WeaponEffect> entities)
    {
        dbContext.RemoveRange(entities);

        await dbContext.SaveChangesAsync();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}