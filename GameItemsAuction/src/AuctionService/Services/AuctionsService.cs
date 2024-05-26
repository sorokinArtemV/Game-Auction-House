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

public class AuctionsService(
    HttpClient httpClient,
    AuctionDbContext context,
    IMapper mapper,
    IConfiguration configuration
) : IAuctionsService
{
    public async Task<IEnumerable<AuctionDto>> GetAllAuctions()
    {
        var auctions = await context.Auctions.ToListAsync();

        var auctionsWithItemDetails = await Task.WhenAll(auctions.Select(AddItemToAuction));

        return auctionsWithItemDetails;
    }

    public async Task<AuctionDto> GetAuctionById(Guid auctionId)
    {
        var auction = await context.Auctions
            .FirstOrDefaultAsync(x => x.Id == auctionId);

        if (auction == null) throw new NotFoundException(nameof(Auction), auctionId.ToString());

        var auctionDto = await AddItemToAuction(auction);

        return auctionDto;
    }

    public async Task<AuctionDto> CreateAuction(CreateAuctionDto createAuctionDto)
    {
        var auction = mapper.Map<Auction>(createAuctionDto);

        // TODO: add current user as seller
        auction.Seller = "test";

        context.Auctions.Add(auction);

        var isCreated = await context.SaveChangesAsync() > 0;

        if (!isCreated) throw new NotSavedToDatabaseException(nameof(Auction));
        
        var auctionDto = mapper.Map<AuctionDto>(auction);

        var itemDetails = await GetItemAsync(auction.ItemId, auction.ItemType);
        
        if (itemDetails == null) throw new NotFoundException(nameof(auction.ItemType), auction.ItemId.ToString());

        auctionDto.ItemDetails = itemDetails;

        return auctionDto;
    }

    public async Task DeleteAuction(Guid auctionId)
    {
        var auction = await context.Auctions.FindAsync(auctionId);
        
        // TODO: check seller == username
        if (auction == null) throw new NotFoundException(nameof(Auction), auctionId.ToString());
        
        context.Auctions.Remove(auction);
        
        await context.SaveChangesAsync();
    }

    private async Task<AuctionDto> AddItemToAuction(Auction auction)
    {
        var auctionDto = mapper.Map<AuctionDto>(auction);

        var itemDetails = await GetItemAsync(auction.ItemId, auction.ItemType);
        
        if (itemDetails == null) throw new NotFoundException(nameof(auction.ItemType), auction.ItemId.ToString());

        auctionDto.ItemDetails = itemDetails;

        return auctionDto;
    }

    private async Task<IItemDetailsDto?> GetItemAsync(int itemId, string itemType)
    {
        var baseAddress = configuration.GetSection("ItemsApiConfig")["BaseUrl"];
        var path = configuration.GetSection("ItemsApiConfig")["Path"];
        var itemNameSpace = configuration.GetSection("ItemsApiConfig")["ItemNameSpace"];

        var response = await httpClient.GetAsync($"{baseAddress}/{path}/{itemType + "s"}/{itemId}");

        if (!response.IsSuccessStatusCode) return null;

        var content = await response.Content.ReadAsStringAsync();

        var type = Type.GetType($"{itemNameSpace}.{itemType.Capitalize()}DetailsDto");

        if (type != null) return JsonConvert.DeserializeObject(content, type) as IItemDetailsDto;

        return null;
    }
}