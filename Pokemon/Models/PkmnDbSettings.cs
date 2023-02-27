namespace Pokemon.Models;

public class PkmnDbSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string PkmnMainCollection { get; set; } = null!;
    public string PkmnVerboseCollection { get; set; } = null!;
    public string AbilitiesCollection { get; set; } = null!;
}