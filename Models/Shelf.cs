using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SWH.Models;

public class Shelf
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; private set; }
    
    
}