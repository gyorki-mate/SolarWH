using MongoDB.Bson;

namespace SWH.Models;

using MongoDB.Bson.Serialization.Attributes;

public class ProductType
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }

    public string Name { get; set; }
    public int Price { get; set; }
    public int Time { get; set; }
    public int MaxCapacity { get; set; }
}