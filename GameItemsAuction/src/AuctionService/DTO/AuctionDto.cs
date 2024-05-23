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
    public string Name { get; set; }
    public int ItemDbId { get; set; }
    public string ItemApiUrl { get; set; }    
    public int CurrentHighBid { get; set; }
    public int ReservePrice { get; set; }
}