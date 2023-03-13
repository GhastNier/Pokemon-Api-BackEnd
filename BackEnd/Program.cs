using BackEnd.Models;
using BackEnd.Services;
using dotenv.net;
using BackEnd.Config;
using Microsoft.OpenApi.Models;
using static BackEnd.Config.OperationFilter;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from a .env file.
DotEnv.Load();
// Get configuration settings from environment variables.

// Add services to the container.
builder.Services.AddSingleton<PkmnService>();
builder.Services.AddSingleton<PokedexService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    if (options == null) throw new ArgumentNullException(nameof(options));
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "BesPokeApi", Version = "v1" });

    options.OperationFilter<OperationNameFilter>();
});
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

var config = new ConfigurationBuilder().AddEnvironmentVariables().Build() ??
             throw new ArgumentNullException($"new ConfigurationBuilder().AddEnvironmentVariables().Build()");
PkmnDbSettings.PkmnDbConfig(builder, config);


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
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();