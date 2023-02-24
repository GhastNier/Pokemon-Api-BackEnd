using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;


namespace Pokemon.Controllers;

[ApiController]
[Route("pokemon/")]
public class PokemonMainController : ControllerBase
{
    private readonly IMongoDatabase _database;

    public PokemonMainController()
    {
        var connectionString = "mongodb+srv://ghastnier:268ab5J0EmXsbPHx@cluster0.glgdodb.mongodb.net/?retryWrites=true&w=majority";
        IMongoClient client = new MongoClient(connectionString);
        _database = client.GetDatabase("pokeapi");
    }

    [HttpGet(Name = "GetPokemon")]
    public string? Get()
    {
        var collection = _database.GetCollection<PokemonMain>("main");
        var queryable = collection.AsQueryable();
        var query = queryable
            .Where(r => r.NatDex == 2)
            .Select(r=> new { r.Name,r.NatDex, r.Favorite, r.Height, r.Sprite, r.Weight });
        return query.First().ToString();
        }
}