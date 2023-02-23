using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pokemon;

public class PokemonMain
{
    public ObjectId Id { get; set; }
    public int Height { get; set; }
    public int NatDex { get; set; }
    public string? Name { get; set; }
    public int Weight { get; set; }
    public bool Favorite { get; set; }
    public string? Sprite { get; set; }
}

public class Pokemons
{
    public ObjectId Id { get; set; }
    public PkmnAbility[]? Abilities { get; set; }
    public int BaseExperience { get; set; }
    public PkmnForm[]? Forms { get; set; }
    public VersionGameIndex[] GameIndices { get; set; }
    public int Height { get; set; }
    public PkmnHeldItems[] HeldItems { get; set; }
    public bool IsDefault { get; set; }
    public string LocationAreaEncounters { get; set; }
    public PkmnMoves[] Moves { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
    [BsonElement("past_types")] public PastType[] PastTypes { get; set; }
    public PkmnSpecies Species { get; set; }
    public PkmnSprites Sprites { get; set; }
    public PkmnStats[] Stats { get; set; }
    public PkmnType[] Types { get; set; }
    public int Weight { get; set; }
    public bool Favorite { get; set; }
    public int NatDex { get; set; }
}

public class PkmnAbility
{
    [BsonElement("is_hidden")] public bool IsHidden { get; set; }
    public int Slot { get; set; }
    public Abilities.Ability Ability { get; set; }
}

public class Name
{
    [BsonElement("name")] public string? BasicName { get; set; }
    public Language Language { get; set; }
}

public class Language
{
    public ObjectId Id { get; set; }
    public string? Name { get; set; }
    public bool Official { get; set; }
    public string? Iso639 { get; set; }
    public string? Iso3166 { get; set; }
    public Name[]? Names { get; set; }
}

public class VersionGroup
{
    public ObjectId Id { get; set; }
    public string? Name { get; set; }
    public int Order { get; set; }
    public Generation Generation { get; set; }
    [BsonElement("move_learn_methods")] public MoveLearnMtd[] MoveLearnMethods { get; set; }
    public Pokedex[] Pokedexes { get; set; }
    
}