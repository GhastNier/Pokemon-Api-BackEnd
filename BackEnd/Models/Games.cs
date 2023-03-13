// using MongoDB.Bson;
// using MongoDB.Bson.Serialization.Attributes;
// using static BackEnd.Types;
//
// namespace BackEnd.Games;
//
// public class VersionGroup
// {
//     [BsonId] [BsonElement("_id")] public ObjectId Id { get; set; }
//     public string? Name { get; set; }
//     public int Order { get; set; }
//     public Generation? Generation { get; set; } 
//     // [BsonElement("move_learn_methods")] public List<MoveLearnMtd>? MoveLearnMethods { get; set; }
//     public List<PkmnPokedex>? PokedexModels { get; set; }
//     public List<Region>? Regions { get; set; }
//     public List<Version>? Versions { get; set; }
// }
//
// public class Generation
// {
//     [BsonId] [BsonElement("_id")] public ObjectId Id { get; set; }
//     public string? Name { get; set; }
//     public List<Ability>? AbilitiesList { get; set; }
//     public List<Name>? NamesList { get; set; }
//     [BsonElement("main_region")] public Region MainRegion { get; set; }
//     public List<PkmnMoves>? MovesList { get; set; }
//     [BsonElement("pokemon_species")] public List<PkmnSpecies>? PkmnSpeciesList { get; set; }
//     public List<PkmnType>? Types { get; set; }
//     [BsonElement("version_group")] public VersionGroup VersionGroup { get; set; }
// }
//
// public class Version
// {
//     [BsonId] [BsonElement("_id")] public ObjectId Id { get; set; }
//     public string? Name { get; set; }
//     public List<Name> Names { get; set; }
//     [BsonElement("version_group")] public VersionGroup VersionGroup { get; set; }
// }
//
// public class PkmnPokedex
// {
//     [BsonId] [BsonElement("_id")] public ObjectId Id { get; set; }
//     public string? Name { get; set; }
//     [BsonElement("is_main_series")] public bool IsMainSeries { get; set; }
//     public List<PkmnDesc>? Descriptions { get; set; }
//     public List<Name>? Names { get; set; }
//     [BsonElement("pokemon_entries")] public List<PkmnEntry>? PkmnEntries { get; set; }
//     public Region Region { get; set; }
//     [BsonElement("version_groups")] public VersionGroup? VersionGroup { get; set; }
//
//     public class PkmnEntry
//     {
//         [BsonElement("entry_number")] public int Entry { get; set; }
//         [BsonElement("pokemon_species")] public List<PkmnSpecies>? PkmnSpeciesList { get; set; }
//     }
// }

namespace BackEnd.Models;