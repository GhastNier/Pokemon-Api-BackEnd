using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pokemon;

public class Abilities
{
    public class Ability
    {
        public ObjectId Id { get; set; }
        [BsonElement("name")] public string AbilityName { get; set; }
        [BsonElement("is_main_series")] public bool IsMainSeries { get; set; }
        public Generation Generation { get; set; }
        [BsonElement("names")] public Names[] AbilityNames { get; set; }
        [BsonElement("effect_entries")] public AbilityEffect[] EffectEntries { get; set; }
        [BsonElement("effect_changes")] public AbilityChange[] EffectChanges { get; set; }
        [BsonElement("flavor_text_entries")] public AbilityFlavorText[] AbilityFlavorTexts { get; set; }
        [BsonElement("pokemon")] public PkmnAbility[] PkmnWithAbility { get; set; }
    }
}