using ItemsService.ItemsServiceApplication.Common;
using ItemsService.ItemsServiceApplication.Items.Weapons.DTO;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Items.Weapons.Queries.GetAllWeapons;

public class GetAllWeaponsQuery : IRequest<PagedResult<WeaponDto>>
{
    public string? SearchPhrase { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 4;
}