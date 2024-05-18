using ItemsService.ItemsServiceApplication.Weapons.DTO;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Weapons.Queries.GetAllWeapons;

public class GetAllWeaponsQuery : IRequest<IEnumerable<WeaponDto>>
{
    
}