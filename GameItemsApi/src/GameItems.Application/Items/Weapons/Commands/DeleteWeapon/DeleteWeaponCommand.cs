using MediatR;

namespace GameItems.Application.Items.Weapons.Commands.DeleteWeapon;

public class DeleteWeaponCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}