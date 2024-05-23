using GameItems.Application.Common;
using GameItems.Application.Items.Armors.DTO;
using GameItems.Core.Constants;
using MediatR;

namespace GameItems.Application.Items.Armors.Queries.GetAllArmors;

public class GetAllArmorsQuery : IRequest<PagedResult<ArmorDto>>
{
    public string? SearchPhrase { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 4;
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}