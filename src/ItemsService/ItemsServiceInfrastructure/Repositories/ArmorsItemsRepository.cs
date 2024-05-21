using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ItemsService.ItemsServiceInfrastructure.Repositories;

public class ArmorsItemsRepository(ItemsDbContext dbContext) : IGenericItemsRepository<Armor>
{
    public async Task<IEnumerable<Armor>> GetAllAsync()
    {
        var armors = await dbContext.Armors
            .Include(a => a.SpecialEffects)
            .ToListAsync();

        return armors;
    }

    public async Task<(IEnumerable<Armor>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber)
    {
        var lowerSearchPhrase = searchPhrase?.ToLower();

        var baseQuery = dbContext.Armors
            .Include(w => w.SpecialEffects)
            .Where(w => lowerSearchPhrase == null || (w.Name.ToLower().Contains(lowerSearchPhrase) ||
                                                      w.ArmorType.ToLower().Contains(lowerSearchPhrase)));
        
        var totalCount = await baseQuery.CountAsync();
        
        var armors = await dbContext.Armors
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (armors, totalCount);
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

    public Task DeleteAsync(Armor entity)
    {
        dbContext.Armors.Remove(entity);

        return dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}