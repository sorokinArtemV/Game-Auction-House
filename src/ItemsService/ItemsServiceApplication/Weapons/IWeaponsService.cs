using ItemsService.ItemServiceCore.Entities.ItemTypes;

namespace ItemsService.ItemsServiceApplication.Weapons;

public interface IWeaponsService
{
    Task<IEnumerable<Weapon>> GetAllAsync();
    Task<Weapon?> GetByIdAsync(int id);
}