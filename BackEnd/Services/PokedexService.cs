using BackEnd.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using static BackEnd.Models.PokedexModels;
using static BackEnd.Models.Pokemons;

namespace BackEnd.Services;

public class PokedexService
{   private readonly IMongoCollection<PokemonBasics> _basicCollection;
    private readonly IMongoCollection<Pokedexes> _pokedexes;
    private readonly IMongoCollection<ByPokemon> _pokedexEntries;
    private readonly IMongoCollection<PokedexDesc> _dexDesc;
    public PokedexService(IOptions<PkmnDb> options)
    {
        var mongoClient = new MongoClient(options.Value.ConnectionString);
        if (mongoClient == null) throw new ArgumentNullException(nameof(mongoClient));
        var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName) ??
                            throw new ArgumentNullException(nameof(options));
        _pokedexes = mongoDatabase.GetCollection<Pokedexes>(options.Value.Pokedexes);
        _basicCollection = mongoDatabase.GetCollection<PokemonBasics>(options.Value.PkmnBasics);
        _pokedexEntries = mongoDatabase.GetCollection<ByPokemon>(options.Value.DexEntries);
        _dexDesc = mongoDatabase.GetCollection<PokedexDesc>(options.Value.TypeList);
    }
    public async Task<IMongoQueryable<Pokedexes>> GetAsync()
    {
        IMongoQueryable<Pokedexes> pkmn = _pokedexes.AsQueryable()
            .Where(p => p.Id == 1)
            .Select(p => new Pokedexes {
                _Id = p._Id,
                DexName = p.DexName
            });
        return pkmn;
    }
}