using AuctionService.DTO;

namespace AuctionService.Interfaces;

public interface IAuctionsService
{
    Task<AuctionDto?> GetAuctionById(Guid auctionId);
}