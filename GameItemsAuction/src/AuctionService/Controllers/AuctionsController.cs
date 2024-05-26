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
        
        return Ok(auction);
    }
}



