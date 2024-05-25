using AuctionService.DTO.ItemDto;

namespace AuctionService.DTO;

public class AuctionDto
{
    public Guid Id { get; set; }
    public string Seller { get; set; }
    public string Winner { get; set; }
    public int SoldAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime AuctionEnd { get; set; }
    public string Status { get; set; }
    public int CurrentHighBid { get; set; }
    public int ReservePrice { get; set; }

    public Object? ItemDetails { get; set; }
    
    // TODO: find solution - may be
    // public T? ItemDetails { get; set; } // where T : Type { get; set; }
    // where T : IItemDetailsDto

}