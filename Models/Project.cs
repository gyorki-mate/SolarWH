using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SWH.Shared.enums;

namespace SWH.Models;

public class Project
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("name")] public string Name { get; set; }

    [BsonElement("location")] public string Location { get; set; }

    [BsonElement("description")] public string Description { get; set; }

    [BsonElement("userName")] public string UserName { get; set; }

    [BsonElement("phoneNumber")] public string PhoneNumber { get; set; }

    [BsonElement("status")] public string Status { get; set; } = "New";

    [BsonElement("cost")] public int Cost { get; set; } = 0;
    [BsonElement("estimatedDate")] public DateOnly  EstimatedDate { get; set; }
    [BsonElement("createdAt")] public DateOnly  CreatedAt { get; set; }
    [BsonElement("updatedAt")] public DateOnly  UpdatedAt { get; set; }

    [BsonElement("products")] public List<ProjectProducts> Products { get; set; }
}