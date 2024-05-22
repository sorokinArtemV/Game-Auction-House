using ItemsService.ItemServiceCore.Constants;
using ItemsService.ItemsServiceApplication.Common;
using ItemsService.ItemsServiceApplication.Items.Armors.DTO;
using MediatR;

namespace ItemsService.ItemsServiceApplication.Items.Armors.Queries.GetAllArmors;

public class GetAllArmorsQuery : IRequest<PagedResult<ArmorDto>>
{
    public string? SearchPhrase { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 4;
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}