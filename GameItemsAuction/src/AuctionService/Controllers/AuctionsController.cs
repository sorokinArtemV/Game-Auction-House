using AuctionService.DTO;
using AuctionService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuctionsController(IAuctionsService auctionsService) : ControllerBase
{
    
    [HttpGet("{auctionId}")]
    public async Task<ActionResult<AuctionDto>> GetAuctionById(Guid auctionId)
    {
        var auction = await auctionsService.GetAuctionById(auctionId);
        
        return Ok(auction);
    }
}


// [HttpGet]
// public async Task<ActionResult<List<AuctionDto>>> GetAllAuctions()
// {
//     // var auctions = await _context.Auctions
//     //     .Include(x => x.Item)
//     //     .OrderBy(x => x.Item.ItemDbId)
//     //     .ToListAsync();
//     //
//     // return _mapper.Map<List<AuctionDto>>(auctions);
//     return null;
// }

// [HttpGet("{auctionId}")]
// public async Task<ActionResult<AuctionDto>> GetAuctionById(Guid auctionId)
// {
//     var auction = await _context.Auctions
//         .FirstOrDefaultAsync(x => x.Id == auctionId);
//
//     if (auction == null) return NotFound();
//
//     if (auction.ItemType == "weapon")
//     {
//         var item = await GetItemAsync<Weapon>(auction.ItemId, auction.ItemType);
//
//         var auctionDto = _mapper.Map<AuctionDto>(auction);
//
//         auctionDto.ItemDetails = item;
//
//         return auctionDto;
//     }
//
//     if (auction.ItemType == "armor")
//     {
//         var item = GetItemAsync<Armor>(auction.ItemId, auction.ItemType);
//     }
//
//
//     return null!;
// }