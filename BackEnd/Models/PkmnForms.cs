// using MongoDB.Bson;
// using MongoDB.Bson.Serialization.Attributes;
// using BackEnd.Games;
//
// namespace BackEnd;
//
// public class PkmnForms
// {
//     public class PkmnForm
//     {
//         [BsonElement("_id")] public ObjectId Id { get; set; }
//         public string? Name { get; set; }
//         public int Order { get; set; }
//         [BsonElement("form_order")] public int FormOrder { get; set; }
//         [BsonElement("is_default")] public bool IsDefault { get; set; }
//         [BsonElement("is_battle_only")] public bool BattleOnly { get; set; }
//         [BsonElement("is_mega")] public bool Mega { get; set; }
//         [BsonElement("form_name")] public string? FormName { get; set; }
//         public List<Pokemons>? BackEnd { get; set; }
//         public List<PkmnFormType>? Types { get; set; }
//         public List<PkmnFormSprites>? PkmnSprite { get; set; }
//         [BsonElement("version_group")] public VersionGroup? VersionGroup { get; set; }
//         public List<Name>? Names { get; set; }
//         [BsonElement("form_names")] public List<Name>? FormNames { get; set; }
//     }
// }
//
// public class PkmnFormSprites
// {
//     [BsonElement("front_default")] public string? FrontDefault { get; set; }
//     [BsonElement("front_shiny")] public string? FrontShiny { get; set; }
//     [BsonElement("Back_default")] public string? BackDefault { get; set; }
//     [BsonElement("BackShiny")] public string? BackShiny { get; set; }
// }
//
// public class PkmnFormType
// {
//     public int Slot { get; set; }
//     public Types.PkmnType Type { get; set; }
// }