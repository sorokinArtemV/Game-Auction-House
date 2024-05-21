using MediatR;

namespace ItemsService.ItemsServiceApplication.Effects.WeaponEffects.Commands.DeleteWeaponEffect;

public class DeleteWeaponEffectCommand(int weaponId, int effectId) : IRequest
{
    public int Id { get; set; } = effectId;
    public int WeaponId { get; set; } = weaponId;
}