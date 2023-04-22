using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SWH.Models;

public class Project
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; private set; }

    [BsonElement("name")] public string Name { get; set; }

    [BsonElement("location")] public string Location { get; set; }
    
    [BsonElement("description")] public string Description { get; set; }
    
    [BsonElement("userName")] public string UserName { get; set; }
    
    [BsonElement("phoneNumber")] public string PhoneNumber { get; set; }
    
    [BsonElement("status")] public string Status { get; set; } = "New";

    [BsonElement("cost")] public int Cost { get; set; } = 0;
    
    [BsonElement("products")] public List<Product> Products { get; set; }
}