using ItemsService.ItemServiceCore.Entities.ItemParameters;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;

namespace ItemsService.ItemsServiceInfrastructure.Repositories;

public class WeaponEffectsRepository(ItemsDbContext dbContext) : IGenericRepository<WeaponEffect>
{
    public async Task<IEnumerable<WeaponEffect>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<WeaponEffect?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

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

    public async Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}