
using SearchService;
using SearchService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<AuctionSvcHttpClient>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    await DbInitializer.InitDb(app);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

app.Run();
