using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Pokemon;

var builder = WebApplication.CreateBuilder(args);
// Check for ENV and Connect to Mongo
var connectionString = "mongodb://ghastnier:268ab5J0EmXsbPHx@cluster0.glgdodb.mongodb.net/?retryWrites=true&w=majority";
// var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
// if (connectionString == null)
// {
//     Console.WriteLine(
//         "You must set your 'MONGODB_URI' environmental variable. See\n\t https://www.mongodb.com/docs/drivers/go/current/usage-examples/#environment-variable");
//     Environment.Exit(0);
// }

var client = new MongoClient(connectionString);
var db = client.GetDatabase("pokeapi");
var mainCollectionQueryable = db.GetCollection<PokemonMain>("main").AsQueryable();
// var pokemonsCollectionQueryable = db.GetCollection<Pokemons>("pokemons").AsQueryable();
var abilitiesCollectionQueryable = db.GetCollection<BsonDocument>("abilities").AsQueryable();
var mainQuery = mainCollectionQueryable.Where(r => r.Name == "bulbasaur")
    .Select((PokemonMain r) => new
    {
        Name = r.Name,
        r.Favorite,
        r.Sprite,
        r.Id,
        r.NatDex,
        r.Height,
        r.Weight
    });
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();