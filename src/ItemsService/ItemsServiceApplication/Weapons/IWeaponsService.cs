using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemsServiceApplication.Weapons.DTO;

namespace ItemsService.ItemsServiceApplication.Weapons;

public interface IWeaponsService
{
    Task<IEnumerable<WeaponDto>> GetAllAsync();
    Task<WeaponDto?> GetByIdAsync(int id);
}