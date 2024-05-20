using ItemsService.ItemsServiceApplication.WeaponEffects.Dto;
using ItemsService.ItemsServiceApplication.Weapons.DTO;
using MediatR;

namespace ItemsService.ItemsServiceApplication.WeaponEffects.Queries.GetAllWeaponEffects;

public class GetAllWeaponEffectsQuery(int weaponId) : IRequest<IEnumerable<WeaponEffectDto>>
{
    public int WeaponId { get; set; } = weaponId;
}