using System.ComponentModel.DataAnnotations;

namespace AuctionService.DTO;

public class CreateAuctionDto
{
    [Required] public string ItemType { get; set; }

    [Required] public int ItemId { get; set; }

    [Required] public int ReservePrice { get; set; }

    [Required] public DateTime AuctionEnd { get; set; }
}