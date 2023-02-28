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
builder.Services.Configure<PkmnDbSettings>(settings =>
{
    settings.ConnectionString = config["MONGODB_URI"];
    settings.DatabaseName = config["DATABASE_NAME"];
    settings.MainCollection = config["MAIN_COLLECTION"];
    settings.VerboseCollection = config["VERBOSE_COLLECTION"];
    settings.AbilitiesCollection = config["ABILITIES_COLLECTION"];
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
