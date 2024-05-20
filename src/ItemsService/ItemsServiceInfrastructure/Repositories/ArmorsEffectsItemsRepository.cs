using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;

namespace ItemsService.ItemsServiceInfrastructure.Repositories;

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
}