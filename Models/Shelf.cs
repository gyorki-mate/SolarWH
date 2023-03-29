using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SWH.Models;

public class Shelf
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; private set; }

    [BsonElement("name")] public string Name { get; set; }

    [BsonElement("products")] public Product Product { get; set; }
    [BsonElement("quantity")] public int Quantity { get; set; }
    
}