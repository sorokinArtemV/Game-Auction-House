using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceInfrastructure.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ItemsService.ItemsServiceInfrastructure.Repositories;

public class WeaponsRepository(ItemsDbContext dbContext) : IGenericRepository<Weapon>
{
    public async Task<IEnumerable<Weapon>> GetAllAsync()
    {
        var weapons = await dbContext.Weapons
            .Include(w => w.SpecialEffects)
            .ToListAsync();

        return weapons;
    }

    public async Task<Weapon?> GetByIdAsync(int id)
    {
        var weapon = await dbContext.Weapons
            .Include(w => w.SpecialEffects)
            .FirstOrDefaultAsync(w => w.Id == id);

        return weapon;
    }
}