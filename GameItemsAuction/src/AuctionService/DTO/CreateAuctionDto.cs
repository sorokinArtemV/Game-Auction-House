using System.ComponentModel.DataAnnotations;

namespace AuctionService.DTO;

public class CreateAuctionDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public int ItemDbId { get; set; }
    
    [Required]
    public string ItemApiUrl { get; set; }    

    [Required]
    public int ReservePrice { get; set; }
    
    [Required]
    public DateTime AuctionEnd { get; set; }
}