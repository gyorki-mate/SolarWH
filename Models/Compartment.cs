using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SWH.Shared.enums;

namespace SWH.Models;

public class Compartment
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; private set; }

    public int CompartmentId { get; set; }
    public List<Shelf> Shelves { get; set; } = new();
}