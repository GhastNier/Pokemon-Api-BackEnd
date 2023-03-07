namespace BackEnd.Models;

public class PkmnDbSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string Main { get; set; } = null!;
    public string EggGroup { get; set; } = null!;

    public string Encounters { get; set; } = null!;

    public string PkmnSprite { get; set; } = null!;
    public string PkmnBasics { get; set; } = null!;
    public string Forms { get; set; } = null!;
    public string Habitat { get; set; } = null!;
    public string Shape { get; set; } = null!;
    public string Species { get; set; } = null!;
    public string Pokedex { get; set; } = null!;
    public string Pokeatlhon { get; set; } = null!;
    public string EvoTrigger { get; set; } = null!;
    public string EvoChain { get; set; } = null!;
    public string Nature { get; set; } = null!;
    public string Stat { get; set; } = null!;
    public string Type { get; set; } = null!;
}