namespace AuctionService.DTO;

public class UpdateAuctionDto
{
    public string? Name { get; set; }
    public int ItemDbId { get; set; }
    public string? ItemApiUrl { get; set; }  
}