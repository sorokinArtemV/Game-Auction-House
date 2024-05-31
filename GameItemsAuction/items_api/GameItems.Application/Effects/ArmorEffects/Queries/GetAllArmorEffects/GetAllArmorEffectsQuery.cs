using GameItems.Application.Effects.ArmorEffects.Dto;
using MediatR;

namespace GameItems.Application.Effects.ArmorEffects.Queries.GetAllArmorEffects;

public class GetAllArmorEffectsQuery(int armorId) : IRequest<IEnumerable<ArmorEffectDto>>
{
    public int ArmorId { get; set; } = armorId;
}