using MongoDB.Driver;
using MongoDB.Bson;
using DotNetEnv;

var envFile = ".env";
if (File.Exists(envFile))
{
    Env.Load(envFile);
}

var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
if (connectionString == null)
{
    Console.WriteLine(
        "You must set your 'MONGODB_URI' environmental variable. See\n\t https://www.mongodb.com/docs/drivers/go/current/usage-examples/#environment-variable");
    Environment.Exit(0);
}

var client = new MongoClient(connectionString);
var collection = client.GetDatabase("pokeapi").GetCollection<BsonDocument>("pokemons");
var filter = Builders<BsonDocument>.Filter.Eq("id", 12);
var document = collection.Find(filter).First();
Console.WriteLine(document);