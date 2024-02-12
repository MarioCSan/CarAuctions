using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Data;

public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        await DB.InitAsync("SearchDb", MongoClientSettings
            .FromConnectionString(app.Configuration
            .GetConnectionString("MongoDbConnection")));

        await DB.Index<Item>()
            .Key(y => y.Make, KeyType.Text)
            .Key(y => y.Model, KeyType.Text)
            .Key(y => y.Color, KeyType.Text)
            .CreateAsync();

        var count = await DB.CountAsync<Item>();

       using var scope = app.Services.CreateScope();

       var httpClient = scope.ServiceProvider.GetRequiredService<AuctionSvcHttpClient>();

       var items = await httpClient.GetItemsForSearchDB();

       Console.WriteLine(items.Count + " returned from de DB");

       if (items.Count > 0) await DB.SaveAsync(items);
    }
}