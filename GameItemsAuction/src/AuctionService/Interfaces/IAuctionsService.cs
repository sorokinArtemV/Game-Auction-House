using AuctionService.DTO;

namespace AuctionService.Interfaces;

public interface IAuctionsService
{
    public Task<IEnumerable<AuctionDto>> GetAllAuctions();
    public Task<AuctionDto?> GetAuctionById(Guid auctionId);
}