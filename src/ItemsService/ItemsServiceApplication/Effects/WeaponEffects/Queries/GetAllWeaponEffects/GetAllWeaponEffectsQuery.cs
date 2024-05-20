using ItemsService.ItemsServiceApplication.Effects.WeaponEffects.Dto;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Effects.WeaponEffects.Queries.GetAllWeaponEffects;

public class GetAllWeaponEffectsQuery(int weaponId) : IRequest<IEnumerable<WeaponEffectDto>>
{
    public int WeaponId { get; set; } = weaponId;
}