using ItemsService.ItemServiceCore.Constants;

namespace ItemsService.Helpers;

public class SearchParams
{
    public string? SearchPhrase { get; set; }
    public WeaponType WeaponType { get; set; }
    public int ItemLevel { get; set; } 
    public int RequiredLevel { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 2;
    public string? OrderBy { get; set; }
    public string? FilterBy { get; set; }
}