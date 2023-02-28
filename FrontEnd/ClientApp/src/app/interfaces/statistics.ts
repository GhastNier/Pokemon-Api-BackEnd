import { NamedAPIResource } from "./named-api-resources";

export namespace Statistics {
  export interface PokemonStat {
    stat: NamedAPIResource;
    effort: number;
    base_stat: number;
  }
}
export namespace Typing {
  export interface PokemonType {
    slot: number;
    type: NamedAPIResource;
  }

  export interface PokemonPastType {
    generation: NamedAPIResource;
    types: PokemonType[];
  }
}
