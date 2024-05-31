using MediatR;

namespace GameItems.Application.Effects.WeaponEffects.Commands.DeleteAllWeaponEffects;

public class DeleteAllWeaponEffectsCommand(int weaponId) : IRequest
{
    public int WeaponId { get; set; } = weaponId;
}