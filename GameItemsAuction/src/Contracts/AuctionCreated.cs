﻿namespace Contracts;

public class AuctionCreated
{
    public Guid Id { get; set; }
    public string? Seller { get; set; }
    public string? Winner { get; set; }
    public int SoldAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime AuctionEnd { get; set; }
    public string? Status { get; set; }
    public int CurrentHighBid { get; set; }
    public int ReservePrice { get; set; }

    public object? ItemDetails { get; set; }
}