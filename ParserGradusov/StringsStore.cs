namespace ParserGradusov
{
    public class StringsStore
    {
        private const string filepath = "D:\\C#proj\\ParserGradusov\\ParserGradusov\\3328496339_40702810010000001390_002_0519.txt";

        private const string MongoDbCollectionName = "usersinfo";
        private const string MongoDbDatabaseName = "ParserUserInfo";
        private const string MongoDbConnectionString = "mongodb://localhost:27017/?directConnection=true";
      
        public static string GetFilePath()
        {
            return filepath;
        }
        public static string GetMongoDbCollection()
        {
            return MongoDbCollectionName;
        }
        public static string GetMongoDbDatabaseName()
        {
            return MongoDbDatabaseName;
        }
        public static string GetMongoDbConnectionString()
        {
            return MongoDbConnectionString;
        }
    }
}
