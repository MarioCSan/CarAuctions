using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;

public class AuctionCreatedConsumer : IConsumer<AuctionCreated>
{
    private readonly IMapper _mapper;

    public AuctionCreatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task Consume(ConsumeContext<AuctionCreated> context)
    {
       Console.WriteLine("--> COnsuming auction created: " + context.Message);

       var item = _mapper.Map<Item>(context.Message);

        if (item.Model == "FOO") throw new ArgumentException("Cannot sell car with that model");

       await item.SaveAsync();
    }
}
