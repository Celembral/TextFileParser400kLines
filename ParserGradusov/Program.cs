using DataAccess;
using ParserGradusov;
using MongoDB.Driver;
using MongoDB.Bson;

string? line = string.Empty;
var filepath = StringsStore.filepath;
var collection = StringsStore.MongoDbCollectionName;
var dbname = StringsStore.MongoDbDatabaseName;
var mongoConnString = StringsStore.MongoDbConnectionString;

StreamReader reader = new StreamReader(filepath);
ParserDbContext dbcontext = new ParserDbContext();
MongoClient client = new MongoClient(mongoConnString);

var db = client.GetDatabase(dbname);

while ((line = reader.ReadLine()) != null)
{
    string[] items = line.Split(';');
    //sql
    IModelFill sqlModelFiller = new SqlModelFill();
    var sqlModel = (FullLineUser)sqlModelFiller.FillModel(items, items.Length);
    dbcontext.FullLineUsers.Add(sqlModel);
    //nosql
    IModelFill noSqlModelFiller = new NoSqlModelFill();
    var noSqlModel = (BsonDocument)noSqlModelFiller.FillModel(items, items.Length);
    var coll = db.GetCollection<BsonDocument>(collection);
    coll.InsertOne(noSqlModel);
}
dbcontext.SaveChanges();