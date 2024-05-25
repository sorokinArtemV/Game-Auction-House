using AuctionService.Data;
using AuctionService.DTO;
using AuctionService.DTO.ItemDto;
using AuctionService.Extensions;
using AuctionService.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AuctionService.Services;

public class AuctionsService(HttpClient httpClient, AuctionDbContext context, IMapper mapper) : IAuctionsService
{
    public async Task<AuctionDto?> GetAuctionById(Guid auctionId)
    {
        var auction = await context.Auctions
            .FirstOrDefaultAsync(x => x.Id == auctionId);

        // TODO: add exception class
        if (auction == null) throw new Exception("Auction not found"); 

        var auctionDto = mapper.Map<AuctionDto>(auction);

        var itemDetails = await GetItemAsync(auction.ItemId, auction.ItemType);
        
        // TODO: add exception class
        if (itemDetails == null) throw new Exception("Item details not found");

        auctionDto.ItemDetails = itemDetails;

        return auctionDto;
    }
    
    private async Task<IItemDetailsDto?> GetItemAsync(int itemId, string itemType)
    {
        // TODO: move to config settings
        var response = await httpClient.GetAsync($"http://localhost:7000/api/items/{itemType + "s"}/{itemId}");

        if (!response.IsSuccessStatusCode) return null;

        var content = await response.Content.ReadAsStringAsync();
        
        var type = Type.GetType($"AuctionService.DTO.ItemDto.{itemType.Capitalize()}DetailsDto");
        
        if (type != null) return JsonConvert.DeserializeObject(content, type) as IItemDetailsDto;
        
        return null;
    }
}