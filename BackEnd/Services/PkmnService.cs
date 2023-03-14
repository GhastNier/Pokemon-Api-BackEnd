using BackEnd.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using static System.Console;
using static BackEnd.Models.Pokemons;
using static BackEnd.Models.PokemonViews;

namespace BackEnd.Services;

public class PkmnService
{
    private readonly IMongoCollection<PokemonBasics> _basicCollection;
    private readonly IMongoCollection<Pokemons.EggGroup> _eggGroup;
    private readonly IMongoCollection<PokemonViews.EggGroup> _byEggGroup;
    private readonly IMongoCollection<ListPkmn.ByType> _byTypeList;

    public PkmnService(IOptions<PkmnDb> options)
    {
        var mongoClient = new MongoClient(options.Value.ConnectionString);
        if (mongoClient == null) throw new ArgumentNullException(nameof(mongoClient));
        var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName) ??
                            throw new ArgumentNullException(nameof(options));
        _basicCollection = mongoDatabase.GetCollection<PokemonBasics>(options.Value.PkmnBasics);
        _eggGroup = mongoDatabase.GetCollection<Pokemons.EggGroup>(options.Value.EggGroup);
        _byEggGroup = mongoDatabase.GetCollection<PokemonViews.EggGroup>(options.Value.EggGroupView);
        _byTypeList = mongoDatabase.GetCollection<ListPkmn.ByType>(options.Value.TypeList);
    }


    public async Task<IMongoQueryable<PokemonBasics>> GetAsync(int natDex)
    {
        var pkmn = _basicCollection.AsQueryable()
            .Where(p => p.NatDex == natDex)
            .Select(p => p => new PokemonBasics
            {
                Name = p.Name,
                NatDex = p.NatDex,
                Height = p.Height,
                Weight = p.Weight,
                Sprite = p.Sprite,
                Favorite = p.Favorite,
                Type1 = p.Type1,
                Type2 = p.Type2
                
            });
        await Task.CompletedTask;
        return pkmn;
    }

    // public async Task CreateAsync(PokemonBasics newPkmn) =>
    //     await _basicsCollections.InsertOneAsync(newPkmn);

    public async Task<PokemonBasics?> UpdateFavAsync(int natDex)
    {
        var pokemon = await _basicCollection.AsQueryable()
            .Where(p => p.NatDex == natDex)
            .FirstOrDefaultAsync();

        if (pokemon == null) return pokemon;
        {
            pokemon.Favorite = !pokemon.Favorite;
            await _basicCollection.ReplaceOneAsync(p => p.NatDex == pokemon.NatDex, pokemon);
            return pokemon;
        }
    }

    public async Task<IMongoQueryable<bool>> GetFavAsync(int natDex)
    {
        var pkmn = _basicCollection.AsQueryable()
            .Where(p => p.NatDex == natDex)
            .Select(p => p.Favorite);
        return pkmn;
    }

    public async Task<List<PokemonBasics>> GetListByPagesAsync(int page)
    {
        var pkmn = _basicCollection.AsQueryable();
        // Get the documents for the specified page
        List<PokemonBasics> results;
        var totalPages = await GetTotalPages();
        if (page > totalPages) page = totalPages;
        if (page < 1)
        {
            results = await pkmn.OrderBy(_ => Guid.NewGuid()).Take(156).ToListAsync();
        }
        else
        {
            // Calculate the number of documents to skip and take based on the page number
            var skipCount = (page == 1) ? 0 : 30 + (page - 2) * 5;
            var takeCount = (page == 1) ? 30 : 5;
            results = await pkmn.OrderBy(doc => doc.NatDex).Skip(skipCount).Take(takeCount).ToListAsync();
            // Get the total count of documents that match the query
        }

        return (results);
    }

    public async Task<Pokemons.EggGroup> GetEggGroupName(int id)
    {
        var pkmn = _eggGroup.AsQueryable();
        var results = await pkmn.Where(p => p.Id == id).FirstOrDefaultAsync();
        return (results);
    }

    public async Task<List<ListPkmn.ByGroup>> GetPokemonListEggByGroupId(int id)
    {
        var pkmn = _byEggGroup.AsQueryable();
        var results = await pkmn.Where(g => g.EggGroupId == id).FirstOrDefaultAsync();
        if (results == null)
        {
            return null;
        }
        var pkmnList = results.Pkmn.Select(pokemon => new ListPkmn.ByGroup
        { NatDex = pokemon.NatDex, PkmnName = pokemon.PkmnName }).ToList();
        return pkmnList;
    }

    public async Task<List<ListPkmn.ByGroup>?> GetPkmnListByEggGroupName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("The name parameter must not be null or empty.", nameof(name));
        }

        var pkmn = _byEggGroup.AsQueryable();
        var results = await pkmn.Where(g => g.EggGroupName.Equals(name)).FirstOrDefaultAsync();

        if (results == null)
        {
            return null;
        }

        if (results.Pkmn == null) return null;
        var pkmnList = results.Pkmn.Select(pokemon => new ListPkmn.ByGroup
            { NatDex = pokemon.NatDex, PkmnName = pokemon.PkmnName }).ToList();
        return pkmnList;
    }

    public async Task<ListPkmn.ByType> GetPkmnTypeList(int typeId)
    {
        var pkmnTypeList = _byTypeList.AsQueryable();
        var results = pkmnTypeList.Where(list => list.Id.Equals(typeId)).FirstOrDefaultAsync();
        return await results;
    }

    private async Task<int> GetTotalPages()
    {
        var pkmn = _basicCollection.AsQueryable().CountAsync();
        var totalCount = await pkmn;
        var totalPages = (int)Math.Ceiling(((double)totalCount - 30) / 5) + 1;
        WriteLine(totalPages);

        return await Task.FromResult(totalPages);
    }
}