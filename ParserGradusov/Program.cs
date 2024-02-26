using DataAccess;
using ParserGradusov;
using Npgsql;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Bson;

string? line = string.Empty;
var filepath = PathHolder.GetFilePath();
StreamReader reader = new StreamReader(filepath);
ParserDbContext dbcontext = new ParserDbContext();
MongoClient client = new MongoClient("mongodb://localhost:27017/?directConnection=true");
var db = client.GetDatabase("ParserUserInfo");
db.CreateCollection("usersinfo");

while ((line = reader.ReadLine()) != null)
{
    string[] items = line.Split(';');
    if (items.Length == 7)
    {
        // SQL model
        FullLineUser fullModel = new()
        {
            Id = Convert.ToInt32(items[0]),
            FIO = items[1],
            Adress = items[2],
            Period = items[3],
            Sum = double.Parse(items[4], new NumberFormatInfo { NumberDecimalSeparator = "." }),
            GasId = items[5],
            GasMeterReads = double.Parse(items[6], new NumberFormatInfo { NumberDecimalSeparator = "." })
        };
        // Adding data to SQL db
        dbcontext.FullLineUsers.Add(fullModel);
        dbcontext.Dispose();

        // NoSQL model
        BsonDocument doc = new BsonDocument
        {
            {"Id",items[0] },
            {"FIO", items[1] },
            {"Address",items[2] },
            {"Period", items[3] },
            {"Sum", items[4] },
            {"GasId", items[5] },
            {"GasMeterReads", items[6] }
        };
        // Adding data to NoSQL db
        var collection = db.GetCollection<BsonDocument>("usersinfo");
        collection.InsertOne(doc);
    }
    else
    {
        // SQL model
        FullLineUser fullModel = new()
        {
            Id = Convert.ToInt32(items[0]),
            FIO = items[1],
            Adress = items[2],
            Period = items[3],
            Sum = double.Parse(items[4], new NumberFormatInfo { NumberDecimalSeparator = "." }),
            GasId = null,
            GasMeterReads = null
        };
        // Adding data to SQL db
        dbcontext.FullLineUsers.Add(fullModel);
        dbcontext.Dispose();

        // NoSQL model
        BsonDocument doc = new BsonDocument
        {
            {"Id",items[0] },
            {"FIO", items[1] },
            {"Address",items[2] },
            {"Period", items[3] },
            {"Sum", items[4] },
            {"GasId", "" },
            {"GasMeterReads", ""}
        };
        // Adding data to NoSQL db
        var collection = db.GetCollection<BsonDocument>("usersinfo");
        collection.InsertOne(doc);
    }
}
// Save changes for SQL db
dbcontext.SaveChanges();
