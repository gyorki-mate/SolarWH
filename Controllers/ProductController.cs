using SWH.Models;
using SWH.Interfaces;
using MongoDB.Driver;

namespace SWH.Controllers;

public class ProductController : IProduct
{
    DbContext _context = new ();

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

    public Product GetProduct(string productID)
    {
        try
        {
            var product = _context.ProductRecord.Find(x => x.id == productID).FirstOrDefault();
            product.ProductType =
                _context.ProductTypeRecord.Find(x => x.id == product.ProductType.id).FirstOrDefault();
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void AddProduct(Product product, string productTypeID)
    {
        try
        {
            var productType = _context.ProductTypeRecord.Find(x => x.id == productTypeID).FirstOrDefault();
            product.ProductType = productType;
            //throw error if product type.MaxCapacity is reached
            if (productType.MaxCapacity <= product.Quantity)
            {
                throw new Exception("Product Type Max Capacity Reached");
            }
            _context.ProductRecord.InsertOne(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async void UpdateProduct(Product product)
    {
        try
        {
            await _context.ProductRecord.ReplaceOneAsync(x => x.id == product.id, product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteProduct(string productID)
    {
        try
        {
            _context.ProductRecord.DeleteOne(x => x.id == productID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}