using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackEnd.Models;

public  class Pokemons
{
    public  class PokemonBasics
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; } = null!;

        [BsonElement("name")] public string Name { get; set; } = null!;

        [BsonElement("natDex")] public int NatDex { get; set; }

        [BsonElement("height")] public int Height { get; set; }

        [BsonElement("weight")] public int Weight { get; set; }

        [BsonElement("sprite")] public string? Sprite { get; set; }

        [BsonElement("favorite")] public bool Favorite { get; set; }
        [BsonElement("type1")] public int Type1 { get; set; }
        [BsonElement("type2")] public int Type2 { get; set; }
    }
    public  class EggGroup
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; } = null!;

        [BsonElement("id")] public int? Id { get; set; }

        [BsonElement("name")] public string? Name { get; set; }

        [BsonElement("nihongo")] public string Japanese { get; set; } = null!;

        [BsonElement("hangugeo")] public string Korean { get; set; } = null!;

        [BsonElement("français")] public string French { get; set; } = null!;

        [BsonElement("deutsch")] public string German { get; set; } = null!;

        [BsonElement("español")] public string Spanish { get; set; } = null!;

        [BsonElement("italiano")] public string Italian { get; set; } = null!;

        [BsonElement("english")] public string English { get; set; } = null!;

        [BsonElement("natDex")] public int[] NatDex { get; set; } = null!;
    }
}

// public class Pokemons
// {
//     [BsonId] [BsonElement("_id")] public ObjectId Id { get; set; }
//     public List<PkmnAbility>? Abilities { get; set; }
//     public int BaseExperience { get; set; }
//     public List<PkmnForms.PkmnForm>? Forms { get; set; }
//     public List<VersionGameIndex>? GameIndices { get; set; }
//     public int Height { get; set; }
//     public List<PkmnHeldItems>? HeldItems { get; set; }
//     public bool IsDefault { get; set; }
//     public string? LocationAreaEncounters { get; set; }
//     public List<PkmnMoves>? Moves { get; set; }
//     public string? Name { get; set; }
//     public int Order { get; set; }
//     [BsonElement("past_types")] public List<PastType>? PastTypes { get; set; }
//     public PkmnSpecies Species { get; set; }
//     public PkmnSprites PkmnSprite { get; set; }
//     public List<PkmnStats>? Stats { get; set; }
//     public List<PkmnType>? Types { get; set; }
//     public int Weight { get; set; }
//     public bool Favorite { get; set; }
//     public int DexByPkmn { get; set; }
//
//     public class PkmnStats
//     {
//         public string? s { get; set; }
//     }
//     
// }

// public class PkmnMoves
// {
//     //public Move Move { get; set; }
//     [BsonElement("version_group_details")] public List<Version>? VersionGroup { get; set; }
//
//     public class Version
//     {
//       //  [BsonElement("move_learn_method")] public MoveLearnMtd LearnMethod { get; set; }
//         // [BsonElement("version_group_details")] public VersionGroup VersionGroup { get; set; }
//         [BsonElement("level_learned_at")] public int LevelLearn { get; set; }
//     }
// }
//
// public class PkmnAbility
// {
//     [BsonElement("is_hidden")] public bool IsHidden { get; set; }
//     public int Slot { get; set; }
//     public Ability? Ability { get; set; }
// }
//
// public class Name
// {
//     [BsonElement("name")] public string? BasicName { get; set; }
//     public Language? Language { get; set; }
// }
//
// public class Language
// {
//     [BsonId] [BsonElement("_id")] public ObjectId Id { get; set; }
//     public string? Name { get; set; }
//     public bool Official { get; set; }
//     public string? Iso639 { get; set; }
//     public string? Iso3166 { get; set; }
//     public List<Name>? Names { get; set; }
// }