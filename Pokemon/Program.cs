using Pokemon.Models;
using Pokemon.Services;
using dotenv.net;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DotEnv.Load();
builder.Services.Configure<PkmnDbSettings>(
    builder.Configuration.GetSection("PokemonMainDatabase")
);
builder.Services.AddSingleton<PkmnMainService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var MyAllowedOrigins = "_myAllowedOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowedOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200","http://localhost:7027")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
builder.Services.Configure<PkmnDbSettings>(settings =>
{
    settings.ConnectionString = config["MONGODB_URI"];
    settings.DatabaseName = config["DATABASE_NAME"];
    settings.MainCollection = config["MAIN_COLLECTION"];
    settings.VerboseCollection = config["VERBOSE_COLLECTION"];
    settings.AbilitiesCollection = config["ABILITIES_COLLECTION"];
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();