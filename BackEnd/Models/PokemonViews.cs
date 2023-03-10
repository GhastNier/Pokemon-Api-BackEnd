﻿using MongoDB.Bson.Serialization.Attributes;

namespace BackEnd.Models;

public class PokemonViews
{
    public class EggGroup
    {
        [BsonElement("eggGroupID")] public int EggGroupId { get; set; }
        [BsonElement("eggGroupName")] public string? EggGroupName { get; set; }
        [BsonElement("pokemons")] public List<ListPkmn.ByGroup>? PkmnList { get; set; }
    }

    public class ListPkmn
    {
        public class ByGroup
        {
            [BsonElement("natDex")] public int NatDex { get; set; }
            [BsonElement("name")] public string PkmnName { get; init; } = null!;
            [BsonElement("sprite")] public string PkmnSprite { get; init; } = null!;
        }

        public class ByType
        {
            [BsonElement("_Id")] public int Id { get; set; }
            [BsonElement("natDex")] public int[] NatDex { get; set; } = null!;
        }
    }
}