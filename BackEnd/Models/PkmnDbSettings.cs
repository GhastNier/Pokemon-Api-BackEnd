namespace BackEnd.Models;

public class PkmnDbSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string MainCollection { get; set; } = null!;
    public string VerboseCollection { get; set; } = null!;
    public string AbilitiesCollection { get; set; } = null!;
}