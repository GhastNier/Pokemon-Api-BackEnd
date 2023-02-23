using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using Pokemon;


namespace Pokemon.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonMainController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<PokemonMainController> _logger;

    public PokemonMainController(ILogger<PokemonMainController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPokemon")]
    public IMongoQueryable<PokemonMain> Get()
    {
        
    }
}