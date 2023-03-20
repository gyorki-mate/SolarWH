namespace SWH.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

public class Warehouse
{
    DbContext context = new DbContext();

    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; } = ObjectId.GenerateNewId().ToString();

    public string[] col1 { get; set; }
    public string[] col2 { get; set; }
    public string[] col3 { get; set; }
    public string[] col4 { get; set; }
    public string[] col5 { get; set; }
    public bool ShowDetails { get; set; }
    
    public Warehouse GetRow(string rowID)
    {
        try
        {
            var row = context.WarehouseRecord.Find(x => x.id == rowID).FirstOrDefault();
            return  row;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}