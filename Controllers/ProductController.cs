using SWH.Models;
using SWH.Interfaces;
using MongoDB.Driver;

namespace SWH.Controllers;

public class ProductController : IProduct
{
    private readonly DbContext _context = new();

    public async Task<List<Product>> GetAllNonStoredProducts()
    {
        try
        {
            var products = await _context.ProductRecord.Find(x => x.IsStored == false && x.Quantity > 0).ToListAsync();
            return products;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<List<Product>> GetAllProducts()
    {
        try
        {
            var products = await _context.ProductRecord.Find(FilterDefinition<Product>.Empty).ToListAsync();
            return products;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Product GetProduct(string productId)
    {
        try
        {
            var product = _context.ProductRecord.Find(x => x.Id == productId).FirstOrDefault();
            // product.ProductType =
            //     _context.ProductTypeRecord.Find(x => x.Id == product.ProductType.Id).FirstOrDefault();
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Product AddProduct(Product product, string productTypeId)
    {
        try
        {
            var productType = _context.ProductTypeRecord.Find(x => x.Id == productTypeId).FirstOrDefault();
            product.ProductType = productType;
            _context.ProductRecord.InsertOne(product);
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async void UpdateProduct(Product product)
    {
        //only when taking away from chest
        
        //TODO check if product type max capacity is reached
        //TODO update Shelf as well
        //TODO dont let Quantity go below 0
        
        try
        {
            await _context.ProductRecord.ReplaceOneAsync(x => x.Id == product.Id, product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void DeleteProduct(string productId)
    {
        try
        {
            _context.ProductRecord.DeleteOne(x => x.Id == productId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}