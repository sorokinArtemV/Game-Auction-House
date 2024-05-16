using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;

namespace ItemsService.ItemsServiceApplication.Weapons;

public class WeaponsService(IGenericRepository<Weapon> repository, ILogger<WeaponsService> logger) : IWeaponsService
{
    public async Task<IEnumerable<Weapon>> GetAllAsync()
    {
        logger.LogInformation("Getting all weapons");
        var weapons = await repository.GetAllAsync();
        
        return weapons;
    }
}