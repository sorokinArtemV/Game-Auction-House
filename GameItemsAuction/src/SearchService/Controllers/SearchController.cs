using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Entities;
using SearchService.Helpers;

namespace SearchService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Item>>> SearchItems([FromQuery] SearchParams searchParams)
    {
        var query = DB.PagedSearch<Item, Item>();

        query.Sort(x => x.Ascending(i => i.RequiredLevel));

        if (!string.IsNullOrEmpty(searchParams.SearchString))
        {
            query.Match(Search.Full, searchParams.SearchString).SortByTextScore();
        }

        query = searchParams.OrderBy switch
        {
            "requiredLevel" => query.Sort(x => x.Ascending(i => i.ItemDetails!.RequiredLevel)),
            "newItem" => query.Sort(x => x.Descending(i => i.CreatedAt)),
            _ => query.Sort(x => x.Ascending(i => i.AuctionEnd))
        };
        
        query = searchParams.FilterBy switch
        {
            "finished" => query.Match(x => x.AuctionEnd < DateTime.UtcNow),
            "endingSoon" => query.Match(x => x.AuctionEnd < DateTime.UtcNow.AddHours(6) && 
                                             x.AuctionEnd > DateTime.UtcNow),
            _ => query.Match(x => x.AuctionEnd > DateTime.UtcNow)
        };

        if (!string.IsNullOrEmpty(searchParams.Seller)) query.Match(x => x.Seller == searchParams.Seller);
        if (!string.IsNullOrEmpty(searchParams.Winner)) query.Match(x => x.Winner == searchParams.Winner);
        

        query.PageNumber(searchParams.PageNumber);
        query.PageSize(searchParams.PageSize);

        var result = await query.ExecuteAsync();

        return Ok(new
        {
            results = result.Results,
            pageCount = result.PageCount,
            totalCount = result.TotalCount
        });
    }
}