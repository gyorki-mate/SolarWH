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
            var products = await _context.ProductRecord.Find(x => x.IsStored == false).ToListAsync();
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

    public void AddProduct(Product product, string productTypeId)
    {
        try
        {
            var productType = _context.ProductTypeRecord.Find(x => x.id == productTypeId).FirstOrDefault();
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
        //only when taking away from chest
        
        //TODO check if product type max capacity is reached
        //TODO update Shelf as well
        if (!product.IsStored) throw new Exception("not_stored");
        try
        {
            await _context.ProductRecord.ReplaceOneAsync(x => x.Id == product.Id, product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteProduct(string productId)
    {
        try
        {
            //TODO update Shelf as well
            _context.CompartmentRecord.DeleteOne(x => x.Shelves.Any(c => c.Product.Id == productId));
            _context.ProductRecord.DeleteOne(x => x.Id == productId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}