using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SWH.Models;

public class Product
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; /*set;*/ }
    public bool IsStored { get; set; }
    public int Quantity { get; set; } = 0;
    public ProductType? ProductType { get; set; }
    public int ShelfId { get; set; }
}
