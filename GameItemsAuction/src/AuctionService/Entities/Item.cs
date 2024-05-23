using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionService.Entities;

[Table("Items")]
public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int ItemDbId { get; set; }
    public string ItemApiUrl { get; set; }

    // navigation
    public Auction Auction { get; set; }
    public Guid AuctionId { get; set; }
}