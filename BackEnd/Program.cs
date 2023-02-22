using MongoDB.Driver;
using MongoDB.Bson;
using DotNetEnv;

var envFile = "env";
if (File.Exists(envFile)) Env.Load(envFile);

var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
if (connectionString == null)
{
    Console.WriteLine(
        "You must set your 'MONGODB_URI' environmental variable. See\n\t https://www.mongodb.com/docs/drivers/go/current/usage-examples/#environment-variable");
    Environment.Exit(0);
}

var client = new MongoClient(connectionString);
var db = client.GetDatabase("pokeapi");
var collectionName = "test";
var indexKey = Builders<BsonDocument>.IndexKeys.Combine(
    Builders<BsonDocument>.IndexKeys.Ascending("_id"),
    Builders<BsonDocument>.IndexKeys.Ascending("name"));
var options = new CreateIndexOptions { Unique = true };
var model = new CreateIndexModel<BsonDocument>(indexKey, options);
db.CreateCollection(collectionName);
db.GetCollection<BsonDocument>(collectionName).Indexes.CreateOne(model);

Console.WriteLine("Collection " + collectionName + " was created");