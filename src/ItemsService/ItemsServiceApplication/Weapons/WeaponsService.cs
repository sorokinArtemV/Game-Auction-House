using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Weapons.DTO;

namespace ItemsService.ItemsServiceApplication.Weapons;

public class WeaponsService(IGenericRepository<Weapon> repository, ILogger<WeaponsService> logger) : IWeaponsService
{
    public async Task<IEnumerable<WeaponDto>> GetAllAsync()
    {
        logger.LogInformation("Getting all weapons");
        var weapons = await repository.GetAllAsync();
        
        return weapons;
    }
    
    public async Task<WeaponDto?> GetByIdAsync(int id)
    {
        logger.LogInformation("Getting weapon with id: {id}", id);
        var weapon = await repository.GetByIdAsync(id);
        
        return weapon;
    }
}