using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SWH.Shared.enums;

namespace SWH.Models;

public class Shelf
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; private set; }

    public int column { get; set; }
    public int row { get; set; }
    public List<Compartment> Compartments { get; set; } = new();
}