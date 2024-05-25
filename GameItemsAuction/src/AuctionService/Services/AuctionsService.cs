using AuctionService.Data;
using AuctionService.DTO;
using AuctionService.DTO.ItemDto;
using AuctionService.Entities;
using AuctionService.Exceptions;
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
        
        if (auction == null) throw new NotFoundException(nameof(Auction), auctionId.ToString()); 

        var auctionDto = mapper.Map<AuctionDto>(auction);

        var itemDetails = await GetItemAsync(auction.ItemId, auction.ItemType);
        
        if (itemDetails == null) throw new NotFoundException(nameof(auction.ItemType), auction.ItemId.ToString());

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