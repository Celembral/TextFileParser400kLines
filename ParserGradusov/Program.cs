﻿using DataAccess;
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

var db = client.GetDatabase(dbname);

while (reader.ReadLine() is { } line)
{
    string[] items = line.Split(';');
    //sql
    var sqlModelFiller = new SqlModelFill();
    var sqlModel = (FullLineUser)sqlModelFiller.FillModel(items);
    dbContext.FullLineUsers.Add(sqlModel);
    //nosql
    var noSqlModelFiller = new NoSqlModelFill();
    var noSqlModel = (BsonDocument)noSqlModelFiller.FillModel(items);
    var coll = db.GetCollection<BsonDocument>(collection);
    coll.InsertOne(noSqlModel);
}
dbContext.SaveChanges();