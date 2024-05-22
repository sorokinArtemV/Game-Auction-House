using GameItems.Core.Entities.ItemParameters;
using GameItems.Core.RepositoryContracts;
using GameItems.Infrastructure.Data.DatabaseContext;

namespace GameItems.Infrastructure.Repositories;

public class ArmorsEffectsItemsRepository(ItemsDbContext dbContext) : IGenericEffectsRepository<ArmorEffect>
{
    public async Task<int> CreateAsync(ArmorEffect entity)
    {
        dbContext.Add(entity);

        await dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task DeleteAsync(ArmorEffect entity)
    {
        dbContext.Remove(entity);

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAllAsync(IEnumerable<ArmorEffect> entities)
    {
        dbContext.RemoveRange(entities);

        await dbContext.SaveChangesAsync();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}