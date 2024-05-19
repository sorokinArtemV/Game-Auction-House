using MediatR;

namespace ItemsService.ItemsServiceApplication.Weapons.Commands.DeleteWeapon;

public class DeleteWeaponCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}