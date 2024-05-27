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
        var query = DB.Find<Item>();

        query.Sort(x => x.Ascending(i => i.RequiredLevel));

        if (!string.IsNullOrEmpty(searchString)) query.Match(Search.Full, searchString).SortByTextScore();
        
        var result = await query.ExecuteAsync();

        return Ok(result);
    }
}