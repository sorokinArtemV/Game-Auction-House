using ItemsService.ItemServiceCore.Entities.ItemTypes;

namespace ItemsService.ItemServiceCore.RepositoryContracts;

public interface IWeaponsRepository
{
    Task<IEnumerable<Weapon>> GetAllAsync();

}