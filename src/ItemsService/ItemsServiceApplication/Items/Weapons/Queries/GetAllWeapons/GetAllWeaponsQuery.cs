using ItemsService.ItemsServiceApplication.Items.Weapons.DTO;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Items.Weapons.Queries.GetAllWeapons;

public class GetAllWeaponsQuery : IRequest<IEnumerable<WeaponDto>>
{
    public string? SearchPhrase { get; set; }
}