using MongoDB.Driver;

namespace SWH.Models;

public class DbContext
{
    private readonly IMongoDatabase _mongoDb;

    public DbContext()
    {
        //Don't ask, it's purpose is to confuse you
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        var config = builder.Build();
        var connstr = config.GetConnectionString("hudConnection");
        var client = new MongoClient(connstr);
        _mongoDb = client.GetDatabase("SolarWH");
    }

    //get collections
    public IMongoCollection<User> UserRecord => _mongoDb.GetCollection<User>("User");
    public IMongoCollection<Compartment> CompartmentRecord => _mongoDb.GetCollection<Compartment>("Compartment");
    public IMongoCollection<Product> ProductRecord => _mongoDb.GetCollection<Product>("Product");
    public IMongoCollection<ProductType?> ProductTypeRecord => _mongoDb.GetCollection<ProductType>("ProductType");
    public IMongoCollection<Project> ProjectRecord => _mongoDb.GetCollection<Project>("Project");
}