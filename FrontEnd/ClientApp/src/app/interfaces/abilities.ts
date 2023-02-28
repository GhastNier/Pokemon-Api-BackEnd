import {NamedAPIResource} from "./named-api-resources";

  export interface PokemonAbility {
    is_hidden: boolean;
    slot: number;
    ability: NamedAPIResource;
}
