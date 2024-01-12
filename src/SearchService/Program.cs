using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await DB.InitAsync("SearchDb", MongoClientSettings
    .FromConnectionString(builder.Configuration
    .GetConnectionString("MongoDbConnection")));

await DB.Index<Item>()
    .Key(y => y.Make, KeyType.Text)
    .Key(y => y.Model, KeyType.Text)
    .Key(y => y.Color, KeyType.Text)
    .CreateAsync();


app.Run();