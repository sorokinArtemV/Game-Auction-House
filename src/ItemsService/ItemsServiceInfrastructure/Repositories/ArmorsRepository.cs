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

    public async Task<Armor?> GetByIdAsync(int id)
    {
        var armor = await dbContext.Armors
            .Include(a => a.SpecialEffects)
            .FirstOrDefaultAsync(a => a.Id == id);
        
        return armor;
    }

    public async Task<int> CreateAsync(Armor entity)
    {
        dbContext.Armors.Add(entity);
        await dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}