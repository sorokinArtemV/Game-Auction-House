using MediatR;

namespace ItemsService.ItemsServiceApplication.WeaponEffects.Commands.DeleteWeaponEffect;

public class DeleteWeaponEffectCommand(int weaponId, int id) : IRequest
{
    public int Id { get; set; } = id;
    public int WeaponId { get; set; } = weaponId;
}