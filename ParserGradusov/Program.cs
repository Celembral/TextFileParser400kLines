using DataAccess;
using ParserGradusov;
using MongoDB.Driver;
using MongoDB.Bson;

const string filepath = StringsStore.Filepath;
const string collection = StringsStore.MongoDbCollectionName;
const string dbname = StringsStore.MongoDbDatabaseName;
const string mongoConnString = StringsStore.MongoDbConnectionString;

var reader = new StreamReader(filepath);
var dbContext = new ParserDbContext();
var client = new MongoClient(mongoConnString);
var noSqlModels = new List<BsonDocument>();
var sqlModels = new List<FullLineUser>();

var db = client.GetDatabase(dbname);
var coll = db.GetCollection<BsonDocument>(collection);

while (reader.ReadLine() is { } line)
{
    string[] items = line.Split(';');
    //sql
    var sqlModelFiller = new SqlModelFill();
    var sqlModel = (FullLineUser)sqlModelFiller.FillModel(items);
    sqlModels.Add(sqlModel);
    //nosql
    var noSqlModelFiller = new NoSqlModelFill();
    var noSqlModel = (BsonDocument)noSqlModelFiller.FillModel(items);
    noSqlModels.Add(noSqlModel);
}

coll.InsertMany(noSqlModels);
dbContext.FullLineUsers.AddRange(sqlModels);
dbContext.SaveChanges();