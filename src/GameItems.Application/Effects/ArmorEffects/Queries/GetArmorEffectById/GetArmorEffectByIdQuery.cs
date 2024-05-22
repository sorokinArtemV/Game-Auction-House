using GameItems.Application.Effects.ArmorEffects.Dto;
using MediatR;

namespace GameItems.Application.Effects.ArmorEffects.Queries.GetArmorEffectById;

public class GetArmorEffectByIdQuery(int armorId, int effectId) : IRequest<ArmorEffectDto>
{
    public int ArmorId { get; } = armorId;
    public int EffectId { get; } = effectId;
}