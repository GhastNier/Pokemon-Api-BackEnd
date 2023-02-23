using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pokemon;

public class PkmnForms
{
    public class PkmnForm
    {
        [BsonElement("_id")] public ObjectId Id { get; set; }
        public string? Name { get; set; }
        public int Order { get; set; }
        [BsonElement("form_order")] public int FormOrder { get; set; }
        [BsonElement("is_default")] public bool IsDefault { get; set; }
        [BsonElement("is_battle_only")] public bool BattleOnly { get; set; }
        [BsonElement("is_mega")] public bool Mega { get; set; }
        [BsonElement("form_name")] public string? FormName { get; set; }
        public Pokemons? Pokemon { get; set; }
        public PkmnFormType[] Types { get; set; }
        public PkmnFormSprites[] Sprites { get; set; }
        [BsonElement("version_group")] private VersionGroup VersionGroup { get; set; }
    }
}