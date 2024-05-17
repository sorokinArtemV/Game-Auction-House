using AutoMapper;
using ItemsService.ItemServiceCore.Entities.ItemTypes;
using ItemsService.ItemServiceCore.RepositoryContracts;
using ItemsService.ItemsServiceApplication.Weapons.DTO;

namespace ItemsService.ItemsServiceApplication.Weapons;

public class WeaponsService(
    IGenericRepository<Weapon> weaponsRepository,
    ILogger<WeaponsService> logger,
    IMapper mapper) : IWeaponsService
{
    public async Task<IEnumerable<WeaponDto>> GetAllAsync()
    {
        logger.LogInformation("Getting all weapons");
        var weapons = await weaponsRepository.GetAllAsync();
        var weaponsDto = mapper.Map<IEnumerable<WeaponDto>>(weapons);

        return weaponsDto;
    }

    public async Task<WeaponDto?> GetByIdAsync(int id)
    {
        logger.LogInformation("Getting weapon with id: {id}", id);
        var weapon = await weaponsRepository.GetByIdAsync(id);

        var weaponDto = mapper.Map<WeaponDto>(weapon);

        return weaponDto;
    }

    public async Task<int> CreateAsync(CreateWeaponDto dto)
    {
        logger.LogInformation("Creating weapon");
        
        var weapon = mapper.Map<Weapon>(dto);

        var id = await weaponsRepository.CreateAsync(weapon);
        
        return id;
    }
}