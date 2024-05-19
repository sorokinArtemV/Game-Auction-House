using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ItemsService.ItemsServiceInfrastructure.Repositories;

public class ArmorsRepository(ItemsDbContext dbContext) : IGenericRepository<Armor>
{
    public async Task<IEnumerable<Armor>> GetAllAsync()
    {
        var armors = await dbContext.Armors
            .Include(a => a.SpecialEffects)
            .ToListAsync();
        
        return armors;
    }

    public Task<Armor?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateAsync(Armor entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Armor entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}