
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pokemon.Models;

namespace Pokemon.Services;

public class PkmnMainService
{
    private readonly IMongoCollection<Models.PokemonMain> _pkmnMainCollection;

    public PkmnMainService(
        IOptions<PokemonDatabaseSettings> pkmnDb)
    {
        var mongoClient = new MongoClient(pkmnDb.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(pkmnDb.Value.DatabaseName);
        _pkmnMainCollection = mongoDatabase.GetCollection<PokemonMain>(pkmnDb.Value.PkmnMainCollection);
    }

    public async Task<List<PokemonMain>> GetAsync() =>
        await _pkmnMainCollection.Find(_ => true).ToListAsync();
    
    public async Task<PokemonMain?> GetAsync(int natDex) =>
        await _pkmnMainCollection.Find(x => x.NatDex == natDex).FirstOrDefaultAsync();

    public async Task CreateAsync(PokemonMain newPkmn) =>
        await _pkmnMainCollection.InsertOneAsync(newPkmn);

    public async Task UpdateAsync(int natDex, PokemonMain updatedPkmn) =>
        await _pkmnMainCollection.ReplaceOneAsync(x => x.NatDex == natDex, updatedPkmn);
    public async Task RemoveAsync(string id) =>
        await _pkmnMainCollection.DeleteOneAsync(x => x.Id == id);
}