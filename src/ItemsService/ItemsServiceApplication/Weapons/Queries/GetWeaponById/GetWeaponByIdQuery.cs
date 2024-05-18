using ItemsService.ItemsServiceApplication.Weapons.DTO;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Weapons.Queries.GetWeaponById;

public class GetWeaponByIdQuery(int id) : IRequest<WeaponDto?>
{
    public int Id { get; set; } = id;
}