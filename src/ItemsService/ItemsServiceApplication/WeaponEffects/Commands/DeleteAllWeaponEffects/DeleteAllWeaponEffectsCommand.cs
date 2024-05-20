using MediatR;

namespace ItemsService.ItemsServiceApplication.WeaponEffects.Commands.DeleteAllWeaponEffects;

public class DeleteAllWeaponEffectsCommand(int weaponId) : IRequest
{
    public int WeaponId { get; set; } = weaponId;
}