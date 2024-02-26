using MongoDB.Bson;

namespace ParserGradusov
{
    public class NoSqlModelFill
    {
        public static BsonDocument FillNoSqlModel(string[] items, int i)
        {
            if (i == 5)
            {
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
                return doc;
            }
            else
            {
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
                return doc;
            }
        }
    }
}
