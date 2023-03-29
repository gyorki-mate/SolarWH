using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SWH.Models;

public class Shelf
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; private set; }

    [BsonElement("name")] public string Name { get; set; }

    [BsonElement("products")] public List<Product> Products { get; set; } = new List<Product>();
}