using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SWH.Models;

public class ProductType
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }
    public int Price { get; set; }
    public int MaxCapacity { get; set; }
}