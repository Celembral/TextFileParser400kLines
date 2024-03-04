using MongoDB.Bson;

namespace ParserGradusov
{
    public class NoSqlModelFill : IModelFill
    {
        public object FillModel(string[] items)
        {
            BsonDocument doc = new BsonDocument
            {
                { "Id", items[0] },
                { "FIO", items[1] },
                { "Address", items[2] },
                { "Period", items[3] },
                { "Sum", items[4] },
                { "GasId", items.Length < 7 ? "" : items[5] },
                { "GasMeterReads", items.Length < 7 ? "" : items[6] }
            };
            return doc;
        }
    }
}
