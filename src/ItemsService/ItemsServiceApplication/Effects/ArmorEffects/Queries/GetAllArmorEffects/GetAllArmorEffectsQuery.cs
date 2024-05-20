using ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Dto;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Effects.ArmorEffects.Queries.GetAllArmorEffects;

public class GetAllArmorEffectsQuery(int armorId) : IRequest<IEnumerable<ArmorEffectDto>>
{
    public int ArmorId { get; set; } = armorId;
}