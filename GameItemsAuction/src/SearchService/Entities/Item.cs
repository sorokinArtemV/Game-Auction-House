using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;

namespace SearchService.Entities;

public class Item : Entity
{
    public string? Seller { get; set; }
    public string? Winner { get; set; }
    public int SoldAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime AuctionEnd { get; set; }
    public string? Status { get; set; }
    public int CurrentHighBid { get; set; }
    public int ReservePrice { get; set; }
    public int RequiredLevel { get; set; }
    public string? ItemType { get; set; }
    public ItemDetails? ItemDetails { get; set; }
}