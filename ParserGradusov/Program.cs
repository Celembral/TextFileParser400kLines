using DataAccess;
using ParserGradusov;
using MongoDB.Driver;
using MongoDB.Bson;

string? line;
const string filepath = StringsStore.Filepath;
const string collection = StringsStore.MongoDbCollectionName;
const string dbname = StringsStore.MongoDbDatabaseName;
const string mongoConnString = StringsStore.MongoDbConnectionString;

var reader = new StreamReader(filepath);
var dbContext = new ParserDbContext();
var client = new MongoClient(mongoConnString);

var db = client.GetDatabase(dbname);

while ((line = reader.ReadLine()) != null)
{
    string[] items = line.Split(';');
    //sql
    IModelFill sqlModelFiller = new SqlModelFill();
    var sqlModel = (FullLineUser)sqlModelFiller.FillModel(items, items.Length);
    dbContext.FullLineUsers.Add(sqlModel);
    //nosql
    IModelFill noSqlModelFiller = new NoSqlModelFill();
    var noSqlModel = (BsonDocument)noSqlModelFiller.FillModel(items, items.Length);
    var coll = db.GetCollection<BsonDocument>(collection);
    coll.InsertOne(noSqlModel);
}
dbContext.SaveChanges();