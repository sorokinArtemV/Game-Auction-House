using GameItems.Application.Effects.WeaponEffects.Dto;
using MediatR;

namespace GameItems.Application.Effects.WeaponEffects.Queries.GetAllWeaponEffects;

public class GetAllWeaponEffectsQuery(int weaponId) : IRequest<IEnumerable<WeaponEffectDto>>
{
    public int WeaponId { get; set; } = weaponId;
}