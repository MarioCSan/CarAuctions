namespace AuctionService.Entities;

public class Item
{

    public Guid Id { get; set; }
    public string Make { get; set; }
    public String Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public int Mileage { get; set; }

    // nav properties
    public Auction Auction { get; set; }
    public Guid AuctionId { get; set; }

}