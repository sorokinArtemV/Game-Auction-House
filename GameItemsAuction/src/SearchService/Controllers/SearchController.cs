using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Entities;

namespace SearchService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Item>>> SearchItems(string? searchString)
    {
        // var query = DB.Find<Item>();
        //
        // query.Sort(x => x.Ascending(a => a.ItemDetails!.ItemLevel));
        //
        // if (!string.IsNullOrEmpty(searchString)) query.Match(Search.Full, searchString).SortByTextScore();
        //
        //
        // var result = await query.ExecuteAsync();
        //
        // var armorItems = result
        //     .Where(x => x.ItemDetails is ArmorDetails)
        //     .Select(x => (ArmorDetails)x.ItemDetails)
        //     .ToList();
        //
        // var weaponItems = result
        //     .Where(x => x.ItemDetails is WeaponDetails)
        //     .Select(x => (WeaponDetails)x.ItemDetails)
        //     .ToList();
        //
        // return Ok(armorItems);

        return null;
    }
}

