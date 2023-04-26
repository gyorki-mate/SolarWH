using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SWH.Shared.enums;

namespace SWH.Models;

public class Compartment
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; private set; }

    public int compartmentId { get; set; }
    public List<Shared.enums.Shelf> Shelves { get; set; } = new();
}