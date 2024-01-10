namespace AuctionService.Entities;

public class Auction
{

    public Guid Id { get; set; }
    public int ReservePrice { get; set; }
    public String Seller { get; set; }
    public String Winner { get; set; }
    public int? SoldAmount { get; set; }
    public int? CurrentHighBid { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
    public Status Status { get; set; }
    public Item Item { get; set; }

}