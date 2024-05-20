using ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Dto;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Queries.GetArmorEffectById;

public class GetArmorEffectByIdQuery(int armorId, int effectId) : IRequest<ArmorEffectDto>
{
    public int ArmorId { get; } = armorId;
    public int EffectId { get; } = effectId;
}