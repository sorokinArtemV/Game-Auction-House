using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetRequiredService<AuctionDbContext>());
    }

    private static void SeedData(AuctionDbContext context)
    {
        context.Database.Migrate();

        if (context.Auctions.Any())
        {
            Console.WriteLine("Database is already seeded");
            return;
        }

        List<Auction> auctions =
        [
            new Auction
            {
                Id = Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "Trall",
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                ItemType = "weapon",
                ItemId = 1
            },
            new Auction
            {
                Id = Guid.Parse("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"),
                Status = Status.Live,
                ReservePrice = 90000,
                Seller = "Illidan",
                AuctionEnd = DateTime.UtcNow.AddDays(60),
                ItemType = "armor",
                ItemId = 4
            },
            new Auction
            {
                Id = Guid.Parse("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"),
                Status = Status.Live,
                Seller = "Arthas",
                AuctionEnd = DateTime.UtcNow.AddDays(4),
                ItemType = "armor",
                ItemId = 1
            },
            new Auction
            {
                Id = Guid.Parse("155225c1-4448-4066-9886-6786536e05ea"),
                Status = Status.ReserveNotMet,
                ReservePrice = 50000,
                Seller = "Uther",
                AuctionEnd = DateTime.UtcNow.AddDays(-10),
                ItemType = "weapon",
                ItemId = 2
            },
            new Auction
            {
                Id = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "Jaina",
                AuctionEnd = DateTime.UtcNow.AddDays(30),
                ItemType = "weapon",
                ItemId = 3
            },
            new Auction
            {
                Id = Guid.Parse("dc1e4071-d19d-459b-b848-b5c3cd3d151f"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "Kadgar",
                AuctionEnd = DateTime.UtcNow.AddDays(45),
                ItemType = "armor",
                ItemId = 2
            },
            new Auction
            {
                Id = Guid.Parse("47111973-d176-4feb-848d-0ea22641c31a"),
                Status = Status.Live,
                ReservePrice = 150000,
                Seller = "Kel-Thuzad",
                ItemType = "weapon",
                ItemId = 4
            },
            new Auction
            {
                Id = Guid.Parse("6a5011a1-fe1f-47df-9a32-b5346b289391"),
                Status = Status.Live,
                Seller = "Anub'arak",
                AuctionEnd = DateTime.UtcNow.AddDays(19),
                ItemType = "armor",
                ItemId = 3
            },
            new Auction
            {
                Id = Guid.Parse("40490065-dac7-46b6-acc4-df507e0d6570"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "Kil'jaeden",
                AuctionEnd = DateTime.UtcNow.AddDays(20),
                ItemType = "weapon",
                ItemId = 5
            },
            new Auction
            {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b9b"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "Grom",
                AuctionEnd = DateTime.UtcNow.AddDays(48),
                ItemType = "armor",
                ItemId = 4
            }
        ];

        context.Auctions.AddRange(auctions);
        context.SaveChanges();
    }
}