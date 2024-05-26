using AuctionService.DTO;
using AuctionService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuctionsController(IAuctionsService auctionsService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<AuctionDto>>> GetAllAuctions()
    {
        var auctions = await auctionsService.GetAllAuctions();

        return Ok(auctions);
    }

    [HttpGet("{auctionId}")]
    public async Task<ActionResult<AuctionDto>> GetAuctionById(Guid auctionId)
    {
        var auction = await auctionsService.GetAuctionById(auctionId);

        return auction;
    }

    [HttpPost]
    public async Task<ActionResult<AuctionDto>> CreateAuction(CreateAuctionDto auctionDto)
    {
        var result = await auctionsService.CreateAuction(auctionDto);

        // fixes System.InvalidOperationException: No route matches the supplied values!
        return CreatedAtAction(nameof(GetAuctionById), new { auctionId = result.Id }, result); 
    }
    
    [HttpDelete("{auctionId}")]
    public async Task<ActionResult> DeleteAuction(Guid auctionId)
    {
        await auctionsService.DeleteAuction(auctionId);
        
        return NoContent();
    }
}