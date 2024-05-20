using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;

namespace ItemsService.ItemsServiceInfrastructure.Repositories;

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
        throw new NotImplementedException();
    }
    
}