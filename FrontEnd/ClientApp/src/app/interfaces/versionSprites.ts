export namespace VersionSprites {
  import GenerationViiIcons = Icons.GenerationViiIcons;
  import GenerationViiiIcons = Icons.GenerationViiiIcons;
  import DreamWorld = OtherGames.DreamWorld;
  import OfficialArtwork = OtherGames.OfficialArtwork;
  import Home = OtherGames.Home;
  import RedBlue = GameSprites.RedBlue;
  import Yellow = GameSprites.Yellow;
  import Crystal = GameSprites.Crystal;
  import Gold = GameSprites.Gold;
  import Silver = GameSprites.Silver;
  import Emerald = GameSprites.Emerald;
  import FireredLeafgreen = GameSprites.FireredLeafgreen;
  import RubySapphire = GameSprites.RubySapphire;
  import DiamondPearl = GameSprites.DiamondPearl;
  import Platinum = GameSprites.Platinum;
  import HeartgoldSoulsilver = GameSprites.HeartgoldSoulsilver;
  import BlackWhite = GameSprites.BlackWhite;
  import OmegarubyAlphasapphire = GameSprites.OmegarubyAlphasapphire;
  import XY = GameSprites.XY;
  import UltraSunUltraMoon = GameSprites.UltraSunUltraMoon;

  export interface VersionSprites {
    "generation-i": GenerationISprites;
    "generation-ii": GenerationIISprites;
    "generation-iii": GenerationIIISprites;
    "generation-iv": GenerationIVSprites;
    "generation-v": GenerationVSprites;
    "generation-vi": GenerationVISprites;
    "generation-vii": GenerationVIISprites;
    "generation-viii": GenerationVIIISprites;
  }
  export interface PokemonSprites {
    front_default: string | null;
    front_shiny: string | null;
    front_female: string | null;
    front_shiny_female: string | null;
    back_default: string | null;
    back_shiny: string | null;
    back_female: string | null;
    back_shiny_female: string | null;
    other?: OtherPokemonSprites;
    versions: VersionSprites;
  }
  export interface OtherPokemonSprites {
    dream_world: DreamWorld;
    "official-artwork": OfficialArtwork;
    home: Home;
  }
  export interface GenerationISprites {
    "red-blue": RedBlue;
    yellow: Yellow;
  }
  export interface GenerationIISprites {
    crystal: Crystal;
    gold: Gold;
    silver: Silver;
  }
  export interface GenerationIIISprites {
    emerald: Emerald;
    "firered-leafgreen": FireredLeafgreen;
    "ruby-sapphire": RubySapphire;
  }
  export interface GenerationIVSprites {
    "diamond-pearl": DiamondPearl;
    "heartgold-soulsilver": HeartgoldSoulsilver;
    platinum: Platinum;
  }
  export interface GenerationVSprites {
    "black-white": BlackWhite;
  }
  export interface GenerationVISprites {
    "omegaruby-alphasapphire": OmegarubyAlphasapphire;
    "x-y": XY;
  }
  export interface GenerationVIIISprites {
    icons: GenerationViiiIcons;
  }
  export interface GenerationVIISprites {
    icons: GenerationViiIcons;
    "ultra-sun-ultra-moon": UltraSunUltraMoon;
  }
}
export namespace GameSprites{
  import Animated = OtherGames.Animated;
  //Gen 1 Sprites
   export interface RedBlue {
    back_default: string | null;
    back_gray: string | null;
    back_transparent: string | null;
    front_default: string | null;
    front_gray: string | null;
    front_transparent: string | null;
  }
  export interface Yellow {
    back_default: string | null;
    back_gray: string | null;
    back_transparent: string | null;
    front_default: string | null;
    front_gray: string | null;
    front_transparent: string | null;
  }
  //Gen 2 Sprites
  export interface Crystal {
    back_default: string | null;
    back_shiny: string | null;
    back_shiny_transparent: string | null;
    back_transparent: string | null;
    front_default: string | null;
    front_shiny: string | null;
    front_shiny_transparent: string | null;
    front_transparent: string | null;
  }
  export interface Gold {
    back_default: string | null;
    back_shiny: string | null;
    front_default: string | null;
    front_shiny: string | null;
    front_transparent: string | null;
  }
  export interface Silver {
    back_default: string | null;
    back_shiny: string | null;
    front_default: string | null;
    front_shiny: string | null;
    front_transparent: string | null;
  }
  //Gen 3 Sprites
  export interface Emerald {
    front_default: string | null;
    front_shiny: string | null;
  }
  export interface FireredLeafgreen {
    back_default: string | null;
    back_shiny: string | null;
    front_default: string | null;
    front_shiny: string | null;
  }
  export interface RubySapphire {
    back_default: string | null;
    back_shiny: string | null;
    front_default: string | null;
    front_shiny: string | null;
  }
  //Gen 4 Sprites
  export interface DiamondPearl {
    back_default: string | null;
    back_shiny: string | null;
    back_female: string | null;
    front_default: string | null;
    front_shiny: string | null;
    back_shiny_female: string | null;
    front_female: string | null;
    front_shiny_female: string | null;
  }
  export interface HeartgoldSoulsilver {
    back_default: string | null;
    back_shiny: string | null;
    back_female: string | null;
    front_default: string | null;
    front_shiny: string | null;
    back_shiny_female: string | null;
    front_female: string | null;
    front_shiny_female: string | null;
  }
  export interface Platinum {
    back_default: string | null;
    back_shiny: string | null;
    back_female: string | null;
    front_default: string | null;
    front_shiny: string | null;
    back_shiny_female: string | null;
    front_female: string | null;
    front_shiny_female: string | null;
  }
  //Gen 5 Sprites
  export interface BlackWhite {
    animated: Animated;
    back_default: string | null;
    back_shiny: string | null;
    back_female: string | null;
    front_default: string | null;
    front_shiny: string | null;
    back_shiny_female: string | null;
    front_female: string | null;
    front_shiny_female: string | null;
  }
  //Gen 6 Sprites
  export interface OmegarubyAlphasapphire {
    front_default: string | null;
    front_female: string | null;
    front_shiny: string | null;
    front_shiny_female: string | null;
  }
  export interface XY {
    front_default: string | null;
    front_female: string | null;
    front_shiny: string | null;
    front_shiny_female: string | null;
  }
  //Gen 7
  export interface UltraSunUltraMoon {
    front_default: string | null;
    front_female: string | null;
    front_shiny: string | null;
    front_shiny_female: string | null;
  }
}
export namespace OtherGames{
  export interface Animated {
  back_default: string | null;
  back_shiny: string | null;
  back_female: string | null;
  front_default: string | null;
  front_shiny: string | null;
  back_shiny_female: string | null;
  front_female: string | null;
  front_shiny_female: string | null;
}
  export interface DreamWorld {
    front_default: string | null;
    front_female: string | null;
  }
  export interface OfficialArtwork {
    front_default: string | null;
  }
  export interface Home {
    front_default: string | null;
    front_female: string | null;
    front_shiny: string | null;
    front_shiny_female: string | null;
  }
}
export namespace Icons{
  export interface GenerationViiIcons {
    front_default: string | null;
    front_female: string | null;
  }

  export interface GenerationViiiIcons {
    front_default: string | null;
    front_female: string | null;
  }
}
