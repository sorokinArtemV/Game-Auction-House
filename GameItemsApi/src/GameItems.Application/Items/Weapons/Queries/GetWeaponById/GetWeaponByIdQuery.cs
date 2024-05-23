using GameItems.Application.Items.Weapons.DTO;
using MediatR;

namespace GameItems.Application.Items.Weapons.Queries.GetWeaponById;

public class GetWeaponByIdQuery(int id) : IRequest<WeaponDto>
{
    public int Id { get; set; } = id;
}