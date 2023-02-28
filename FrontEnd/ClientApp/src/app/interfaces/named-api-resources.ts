export interface NamedAPIResource {
  name: string;
  url: string;
}
export interface VersionGameIndex {
  game_index: number;
  version: NamedAPIResource;
}
export namespace items{
  export interface PokemonHeldItem {
    item: NamedAPIResource;
    version_details: PokemonHeldItemVersion[];
  }

  export interface PokemonHeldItemVersion {
    version: NamedAPIResource;
    rarity: number;
  }
}
export namespace moves{
  export interface PokemonMove {
    move: NamedAPIResource;
    version_group_details: PokemonMoveVersion[];
  }

  export interface PokemonMoveVersion {
    move_learn_method: NamedAPIResource;
    version_group: NamedAPIResource;
    level_learned_at: number;
  }
}
