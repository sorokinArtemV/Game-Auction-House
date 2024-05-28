using MongoDB.Entities;
using SearchService.Entities;

namespace SearchService.Services;

public class AuctionServiceHttpClient(HttpClient httpClient, IConfiguration config)
{
    public async Task<List<Item>> GetAllItemsForSearchDb()
    {
        var lastUpdated = await DB.Find<Item, string>()
            .Sort(x => x.Descending(y => y.UpdatedAt))
            .Project(x => x.UpdatedAt.ToString())
            .ExecuteFirstAsync();

        return await httpClient.GetFromJsonAsync<List<Item>>(
                   config["AuctionsServiceUrl"] + "/api/auctions?date=" + lastUpdated)
               ?? throw new InvalidOperationException("Could not get data from AuctionsService");
    }
}