using MongoDB.Bson;

namespace SWH.Models;

using MongoDB.Bson.Serialization.Attributes;

public class Product
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; private set; }
    [BsonElement("name")] public string Name { get; set; }
    [BsonElement("price")] public int Price { get; set; }
    [BsonElement("maxQuantity")] public int MaxQuantity { get;  set; }
}