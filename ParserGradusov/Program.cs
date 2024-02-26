using DataAccess;
using ParserGradusov;
using MongoDB.Driver;
using MongoDB.Bson;

string? line = string.Empty;
var filepath = StringsStore.GetFilePath();
var collection = StringsStore.GetMongoDbCollection();
var dbname = StringsStore.GetMongoDbDatabaseName();
var mongoConnString = StringsStore.GetMongoDbConnectionString();

StreamReader reader = new StreamReader(filepath);
ParserDbContext dbcontext = new ParserDbContext();
MongoClient client = new MongoClient(mongoConnString);

var db = client.GetDatabase(dbname);

while ((line = reader.ReadLine()) != null)
{
    string[] items = line.Split(';');
    dbcontext.FullLineUsers.Add(SqlModelFill.FillSqlModel(items, items.Length));
    var coll = db.GetCollection<BsonDocument>(collection);
    coll.InsertOne(NoSqlModelFill.FillNoSqlModel(items, items.Length));
}
dbcontext.SaveChanges();