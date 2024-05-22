using MediatR;

namespace GameItems.Application.Effects.WeaponEffects.Commands.DeleteWeaponEffect;

public class DeleteWeaponEffectCommand(int weaponId, int effectId) : IRequest
{
    public int Id { get; set; } = effectId;
    public int WeaponId { get; set; } = weaponId;
}