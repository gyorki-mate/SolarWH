using System.Text;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace SWH.Models;

public class DbContext
{
    private IMongoDatabase _mongoDB;

    public DbContext()
    {
        //Don't ask, it's purpose is to confuse you
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        var config = builder.Build();
        var connstr = config.GetConnectionString("hudConnection");
        var client = new MongoClient(connstr);
        _mongoDB = client.GetDatabase("SolarWH");
    }
    
    //get collections
    public IMongoCollection<User> UserRecord => _mongoDB.GetCollection<User>("User");
    public IMongoCollection<Compartment> CompartmentRecord => _mongoDB.GetCollection<Compartment>("Compartment");
    public IMongoCollection<Product> ProductRecord => _mongoDB.GetCollection<Product>("Product");
    public IMongoCollection<ProductType> ProductTypeRecord => _mongoDB.GetCollection<ProductType>("ProductType");
    public IMongoCollection<Project> ProjectRecord => _mongoDB.GetCollection<Project>("Project");
}