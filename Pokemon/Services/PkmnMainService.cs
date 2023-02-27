using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Pokemon.Models;

namespace Pokemon.Services;

public class PkmnMainService
{
    private readonly IMongoCollection<PokemonMain> _mainCollection;

    public PkmnMainService(IOptions<PkmnDbSettings> options)
    {
        var mongoClient = new MongoClient(options.Value.ConnectionString);
        if (mongoClient == null) throw new ArgumentNullException(nameof(mongoClient));
        var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName) ??
                            throw new ArgumentNullException(nameof(options));
        _mainCollection = mongoDatabase.GetCollection<PokemonMain>(options.Value.MainCollection);
    }


    public async Task<PokemonMain> GetAsync(int natDex)
    {
        var pkmn = await _mainCollection.Find(p => p.NatDex == natDex).FirstOrDefaultAsync();
        Console.WriteLine(pkmn);
        return pkmn;
    }

    public async Task CreateAsync(PokemonMain newPkmn) =>
        await _mainCollection.InsertOneAsync(newPkmn);

    public async Task UpdateFavAsync(int natDex)
    {
        var filter = Builders<PokemonMain>.Filter.Eq(p => p.NatDex, natDex);
        var favBool = await GetFavBoolean(natDex);
        var update = Builders<PokemonMain>.Update.Set(p => p.Favorite,favBool);
        await _mainCollection.UpdateOneAsync(filter, update);
    }
    public async Task RemoveAsync(int natDex) =>
        await _mainCollection.DeleteOneAsync(x => x.NatDex == natDex);

    public Task<PokemonMain> GetFavorite(int natDex)
    {
        var pkmn = _mainCollection.Find(p => p.NatDex == natDex).First();
        return Task.FromResult(pkmn);
    }

    public async Task<bool> GetFavBoolean(int natDex)
    {
        var pkmn = await _mainCollection.AsQueryable()
            .Where(p => p.NatDex == natDex)
            .Select(p => !p.Favorite)
            .FirstOrDefaultAsync();

        return pkmn;
    }
}