using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// using Pokemon.Games;

namespace Pokemon.Models;

public abstract class Ability
{
    public ObjectId Id { get; set; }
    [BsonElement("name")] public string? Name { get; set; }
    [BsonElement("is_main_series")] public bool IsMainSeries { get; set; }
    // public Generation? Generation { get; set; }
    [BsonElement("names")] public List<Name>? Names { get; set; }
    [BsonElement("effect_entries")] public List<AbilityEffect>? EffectEntries { get; set; }
    [BsonElement("effect_changes")] public List<AbilityChange>? EffectChanges { get; set; }
    [BsonElement("flavor_text_entries")] public List<AbilityFlavorText>? AbilityFlavorTexts { get; set; }
    [BsonElement("pokemon")] public List<PkmnAbility>? PkmnWithAbility { get; set; }
    public abstract class AbilityEffect
    {
        public string? Effect { get; set; }
        [BsonElement("short_effect")] public string? ShortEffect { get; set; }
        public Language? Language { get; set; }
    }

    public abstract class AbilityChange
    {
        [BsonElement("effect_entries")]public List<Effect>? Effects { get; set; }
        // [BsonElement("version_group")]public VersionGroup VersionGroup { get; set; }

        public abstract class Effect
        {
            [BsonElement("effect")]public string? EffectText { get; set; }
            public Language? Language { get; set; }
        }
    }
    public abstract class AbilityFlavorText
    {
        [BsonElement("flavor_text")]public string? FlavorText { get; set; }
        public Language? Language { get; set; }
        // [BsonElement("version_group")]public VersionGroup VersionGroup { get; set; }
    }
}