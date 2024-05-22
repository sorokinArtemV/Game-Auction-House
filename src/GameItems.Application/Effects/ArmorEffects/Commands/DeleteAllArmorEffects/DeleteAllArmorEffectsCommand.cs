using MediatR;

namespace GameItems.Application.Effects.ArmorEffects.Commands.DeleteAllArmorEffects;

public class DeleteAllArmorEffectsCommand(int armorId) : IRequest
{
    public int ArmorId { get; set; } = armorId;
}