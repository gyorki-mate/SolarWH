using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SWH.Models;

public class Row
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; private set; }

    [BsonElement("name")] public string Name { get; set; }

    [BsonElement("columns")] public List<Column> Columns { get; set; }
}