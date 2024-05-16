using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Weapons.DTO;

namespace ItemsService.ItemsServiceApplication.Weapons;

public class WeaponsService(
    IGenericRepository<Weapon> repository,
    ILogger<WeaponsService> logger,
    IMapper mapper) : IWeaponsService
{
    public async Task<IEnumerable<WeaponDto>> GetAllAsync()
    {
        logger.LogInformation("Getting all weapons");
        var weapons = await repository.GetAllAsync();
        var weaponsDto = mapper.Map<IEnumerable<WeaponDto>>(weapons);

        return weaponsDto;
    }

    public async Task<WeaponDto?> GetByIdAsync(int id)
    {
        logger.LogInformation("Getting weapon with id: {id}", id);
        var weapon = await repository.GetByIdAsync(id);

        var weaponDto = mapper.Map<WeaponDto>(weapon);

        return weaponDto;
    }
}