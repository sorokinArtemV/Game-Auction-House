using GameItems.Application.Effects.WeaponEffects.Dto;
using MediatR;

namespace GameItems.Application.Effects.WeaponEffects.Queries.GetWeaponEffectById;

public class GetWeaponEffectByIdQuery(int weaponId, int id) : IRequest<WeaponEffectDto>
{
    public int Id { get; set; } = id;
    public int WeaponId { get; set; } = weaponId;
}