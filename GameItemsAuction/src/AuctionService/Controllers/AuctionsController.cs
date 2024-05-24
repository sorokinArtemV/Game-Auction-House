using AuctionService.Data;
using AuctionService.DTO;
using AuctionService.DTO.ItemDto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AuctionService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuctionsController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly AuctionDbContext _context;
    private readonly IMapper _mapper;

    public AuctionsController(HttpClient httpClient, AuctionDbContext context, IMapper mapper)
    {
        _httpClient = httpClient;
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{auctionId}")]
    public async Task<ActionResult<AuctionDto>> GetAuctionById(Guid auctionId)
    {
        var auction = await _context.Auctions
            .FirstOrDefaultAsync(x => x.Id == auctionId);

        if (auction == null) return NotFound();

        var auctionDto = _mapper.Map<AuctionDto>(auction);

        // Dynamically get the item details based on the ItemType
        IItemDetailsDto? itemDetails;
        switch (auction.ItemType.ToLower())
        {
            case "weapon":
                itemDetails = await GetItemAsync<WeaponDetailsDto>(auction.ItemId, auction.ItemType);
                break;
            case "armor":
                itemDetails = await GetItemAsync<ArmorDetailsDto>(auction.ItemId, auction.ItemType);
                break;
            default:
                return BadRequest("Invalid item type.");
        }

        if (itemDetails == null) return NotFound("Item details not found.");

        auctionDto.ItemDetailsDto = itemDetails;

        return Ok(auctionDto);
    }

    private async Task<T?> GetItemAsync<T>(int itemId, string itemType) where T : IItemDetailsDto
    {
        var response = await _httpClient.GetAsync($"http://localhost:7000/api/items/{itemType}s/{itemId}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        return null;
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
    
