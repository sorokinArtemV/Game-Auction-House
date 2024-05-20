using ItemsService.ItemsServiceApplication.Items.Weapons.DTO;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Items.Weapons.Queries.GetWeaponById;

public class GetWeaponByIdQuery(int id) : IRequest<WeaponDto>
{
    public int Id { get; set; } = id;
}