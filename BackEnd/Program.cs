using BackEnd.Models;
using BackEnd.Services;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from a .env file.
DotEnv.Load();

// Add services to the container.
builder.Services.Configure<PkmnDbSettings>(builder.Configuration.GetSection("PokemonMainDatabase"));
builder.Services.AddSingleton<PkmnMainService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Set up CORS policy to allow requests from localhost.
builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalhostPolicy", originCors =>
    {
        originCors.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Get configuration settings from environment variables.
IConfigurationRoot config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
builder.Services.Configure<PkmnDbSettings>(pkmnSettings =>
{
    pkmnSettings.ConnectionString = config["MONGODB_URI"];
    pkmnSettings.DatabaseName = config["PKMN_DB"];
    pkmnSettings.Main = config["PKMN_COLLECTION"];
    pkmnSettings.PkmnBasics = config["PKMN_BASICS"];
    pkmnSettings.PkmnSprite = config["PKMN_SPRITES"];
    pkmnSettings.Encounters = config["PKMN_ENCOUNTERS"];
    pkmnSettings.Forms = config["PKMN_FORMS"];
    pkmnSettings.Habitat = config["PKMN_HABITAT"];
    pkmnSettings.Shape = config["PKMN_SHAPE"];
    pkmnSettings.Species = config["PKMN_SPECIES"];
    pkmnSettings.Pokedex = config["PKMN_POKEDEX"];
    pkmnSettings.Pokeatlhon = config["PKMN_POKEATHLON"];
    pkmnSettings.Stat = config["PKMN_STAT"];
    pkmnSettings.Type = config["PKMN_TYPE"];
    pkmnSettings.Nature = config["PKMN_NATURE"];
    pkmnSettings.EvoChain = config["PKMN_CHAIN"];
    pkmnSettings.EvoTrigger = config["PKMN_EVO_TRIGGER"];
    pkmnSettings.EggGroup = config["PKMN_EGG_GROUP"];
});



// Build the application.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("LocalhostPolicy");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
