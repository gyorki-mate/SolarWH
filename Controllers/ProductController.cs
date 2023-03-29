using SWH.Models;
using SWH.Interfaces;
using MongoDB.Driver;
namespace SWH.Controllers;

public class ProductController : IProduct
{
    DbContext context = new DbContext();
    public async Task<List<Product>> GetAllProducts()
    {
        try
        {
            var products = context.ProductRecord.Find(FilterDefinition<Product>.Empty).ToListAsync();
            return await products;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Product GetProduct(string productID)
    {
        throw new NotImplementedException();
    }

    public async void AddProduct(Product product)
    {
        try
        {
            await context.ProductRecord.InsertOneAsync(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(string productID)
    {
        throw new NotImplementedException();
    }
}