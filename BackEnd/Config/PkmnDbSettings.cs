using BackEnd.Models;

namespace BackEnd.Config;

public class PkmnDbSettings
{
    public static IServiceCollection PkmnDbConfig(WebApplicationBuilder webApplicationBuilder, IConfigurationRoot config)
    {
        return webApplicationBuilder.Services.Configure<PkmnDb>(pkmnSettings =>
        {
            pkmnSettings.ConnectionString = config["MONGODB_URI"]!;
            pkmnSettings.DatabaseName = config["DB"];
            pkmnSettings.PkmnFull = config["COLLECTION"]!;
            pkmnSettings.PkmnBasics = config["BASICS"];
            pkmnSettings.PkmnSprite = config["SPRITES"]!;
            pkmnSettings.Encounters = config["ENCOUNTERS"]!;
            pkmnSettings.Forms = config["FORMS"]!;
            pkmnSettings.Habitat = config["HABITAT"]!;
            pkmnSettings.Shape = config["SHAPE"]!;
            pkmnSettings.Species = config["SPECIES"]!;
            pkmnSettings.Pokedex = config["POKEDEX"]!;
            pkmnSettings.Pokeatlhon = config["POKEATHLON"]!;
            pkmnSettings.Nature = config["NATURE"]!;
            pkmnSettings.EvoChain = config["CHAIN"]!;
            pkmnSettings.EvoTrigger = config["EVO_TRIGGER"]!;
            pkmnSettings.EggGroup = config["EGG_GROUP"]!;
            pkmnSettings.Stat = config["STAT"]!;
            pkmnSettings.Type = config["TYPE"]!;
            pkmnSettings.EggGroupView = config["EGGGROUP"];
        });
    }
}