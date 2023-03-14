using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using static BackEnd.Models.PokedexDesc;
using static BackEnd.Models.PokedexModels.Pokedexes;

namespace BackEnd.Models;

public class PokedexModels
{
    
    public List<DexCription> DexCriptions { get; set; }
    public class Pokedexes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; } = null!;
        [BsonElement("name")] public string? DexName { get; set; }
        [BsonElement("localization")] public List<DexCription> DexCriptions { get; set; }
        [BsonElement("IDs")] public VersionIDs? IDs { get; set; }
        public class DexCription
        {
    
            [BsonElement("description")] public string? LocalDescription { get; set; }
            [BsonElement("languageId")] public int? LanguageId { get; set; }
        }
    }
}



public class ByPokemon
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string _id { get; set; } = null!;

    [BsonElement("natDex")] public int? natDex { get; set; } = null!;
    [BsonElement("CrownThundra")] public int? CrownThundra { get; set; }
    [BsonElement("extSinhho")] public int? ExtSinhho { get; set; }
    [BsonElement("Galar")] public int? Galar { get; set; }
    [BsonElement("Hisui")] public int? Hisui { get; set; }
    [BsonElement("Hoenn")] public int Hoenn { get; set; }
    [BsonElement("IoADex")] public int? IslesOfArmor { get; set; }
    [BsonElement("kalCenDex")] public int? CentralKalos { get; set; }
    [BsonElement("kalCoastDex")] public int? CoastalKalos { get; set; }
    [BsonElement("kalMounttDex")] public int? MountainKalos { get; set; }
    [BsonElement("kanDex")] public int? Kanto { get; set; }
    [BsonElement("letKanDex")] public int? LetsGoKanto { get; set; }
    [BsonElement("oriAloAkaDex")] public int? oriAloAkaDex { get; set; }
    [BsonElement("oriAloDex")] public int? oriAloDex { get; set; }
    [BsonElement("oriAloMelDex")] public int? oriAloMelDex { get; set; }
    [BsonElement("oriAloPoniDex")] public int? oriAloPoniDex { get; set; }
    [BsonElement("oriAloUlaDex")] public int? oriAloUlaDex { get; set; }
    [BsonElement("oriJohDex")] public int? oriJohDex { get; set; }
    [BsonElement("oriSinDex")] public int? oriSinDex { get; set; }
    [BsonElement("oriUnoDex")] public int? oriUnoDex { get; set; }
    [BsonElement("paldeaDex")] public int? paldeaDex { get; set; }
    [BsonElement("updAloAkaDex")] public int? updAloAkaDex { get; set; }
    [BsonElement("updAloDex")] public int? updAloDex { get; set; }
    [BsonElement("updAloMelDex")] public int? updAloMelDex { get; set; }
    [BsonElement("updAloPoniDex")] public int? updAloPoniDex { get; set; }
    [BsonElement("updAloUlaDex")] public int? updAloUlaDex { get; set; }
    [BsonElement("updHoeDex")] public int? updHoeDex { get; set; }
    [BsonElement("updJohDex")] public int? UpdJohDex { get; set; }
    [BsonElement("updUnoDex")] public int? updUnoDex { get; set; }
}

public class PokedexDesc
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string _id { get; set; } = null!;

    [BsonElement("IDs")] public VersionIDs? IDS { get; set; }
    [BsonElement("description")] public DexDescription? Descriptions { get; set; }

    public class DexDescription
    {
        [BsonElement("description")] public string? Description { get; set; }
        [BsonElement("langId")] public int? LangID { get; set; }
    }

    
}

public class PkmnPokedex
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string _id { get; set; } = null!;

    [BsonElement("id")] public int? natDex { get; set; } = null!;
    [BsonElement("dexEntries")] public dexEntries? Entries { get; set; }

    public class dexEntries
    {
        [BsonElement("natDex")] public int? natDex { get; set; } = null!;
        [BsonElement("ctDex")] public int? CrownThundra { get; set; }
        [BsonElement("extSinDex")] public int? ExtSinhho { get; set; }
        [BsonElement("galarDex")] public int? Galar { get; set; }
        [BsonElement("hisuiDex")] public int? Hisui { get; set; }
        [BsonElement("hoeDex")] public int? Hoenn { get; set; }
        [BsonElement("IoADex")] public int? IslesOfArmor { get; set; }
        [BsonElement("kalCenDex")] public int? CentralKalos { get; set; }
        [BsonElement("kalCoastDex")] public int? CoastalKalos { get; set; }
        [BsonElement("kalMounttDex")] public int? MountainKalos { get; set; }
        [BsonElement("kanDex")] public int? Kanto { get; set; }
        [BsonElement("letKanDex")] public int? LetsGoKanto { get; set; }
        [BsonElement("oriAloAkaDex")] public int? OriAloAkaDex { get; set; }
        [BsonElement("oriAloDex")] public int? OriAloDex { get; set; }
        [BsonElement("oriAloMelDex")] public int? oriAloMelDex { get; set; }
        [BsonElement("oriAloPoniDex")] public int? oriAloPoniDex { get; set; }
        [BsonElement("oriAloUlaDex")] public int? oriAloUlaDex { get; set; }
        [BsonElement("oriJohDex")] public int? oriJohDex { get; set; }
        [BsonElement("oriSinDex")] public int? oriSinDex { get; set; }
        [BsonElement("oriUnoDex")] public int? oriUnoDex { get; set; }
        [BsonElement("paldeaDex")] public int? paldeaDex { get; set; }
        [BsonElement("updAloAkaDex")] public int? updAloAkaDex { get; set; }
        [BsonElement("updAloDex")] public int? updAloDex { get; set; }
        [BsonElement("updAloMelDex")] public int? updAloMelDex { get; set; }
        [BsonElement("updAloPoniDex")] public int? updAloPoniDex { get; set; }
        [BsonElement("updAloUlaDex")] public int? updAloUlaDex { get; set; }
        [BsonElement("updHoeDex")] public int? updHoeDex { get; set; }
        [BsonElement("updJohDex")] public int? UpdJohDex { get; set; }
        [BsonElement("updUnoDex")] public int? updUnoDex { get; set; }
    }
}

public class Localization
{
    [BsonElement("languageId")] public int? LanguageId { get; set; }
    [BsonElement("localDexName")] public string? LocalizedName { get; set; }
}
public class VersionIDs
{
    [BsonElement("dexId")] public int? DexId { get; set; }
    [BsonElement("versId")] public int? VersionId { get; set; }
    [BsonElement("regId")] public int? RegionId { get; set; }
}
