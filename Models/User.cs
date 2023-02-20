namespace SWH.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class User
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; } = ObjectId.GenerateNewId().ToString();
    public string role { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
}