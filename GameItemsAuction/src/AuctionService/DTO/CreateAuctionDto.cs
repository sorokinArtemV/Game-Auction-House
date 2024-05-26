using System.ComponentModel.DataAnnotations;

namespace AuctionService.DTO;

public class CreateAuctionDto
{
    public string? ItemType { get; set; }

    public int ItemId { get; set; }

    public int ReservePrice { get; set; }

    public DateTime AuctionEnd { get; set; }
}