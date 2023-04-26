using MongoDB.Bson;
using MongoDB.Driver;

namespace SWH.Models;

using MongoDB.Bson.Serialization.Attributes;

public class Product
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public bool IsStored { get; set; }
    public int Quantity { get; set; }
    public ProductType ProductType { get; set; }

    // TODO what happens if the product is not in the warehouse?
}