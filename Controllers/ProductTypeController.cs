using SWH.Models;
using SWH.Interfaces;
using MongoDB.Driver;

namespace SWH.Controllers;

public class ProductTypeController : IProductType
{
    private readonly DbContext _context = new();

    public async Task<List<ProductType?>> GetAllProductTypes()
    {
        try
        {
            Task<List<ProductType?>> types = _context.ProductTypeRecord.Find(FilterDefinition<ProductType>.Empty).ToListAsync();
            return await types;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public ProductType GetProductType(string typeId)
    {
        try
        {
            var productType = _context.ProductTypeRecord.Find(x => x.Id == typeId).FirstOrDefault();
            return productType;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async void AddProductType(ProductType? type)
    {
        try
        {
            await _context.ProductTypeRecord.InsertOneAsync(type);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async void UpdateProductType(ProductType? type)
    {
        try
        {
            await _context.ProductTypeRecord.ReplaceOneAsync(x => x.Id == type.Id, type);
            //populate the product type
            var productList = await _context.ProductRecord.Find(x => x.ProductType.Id == type.Id).ToListAsync();
            foreach (var p in productList)
            {
                p.ProductType = type;
                await _context.ProductRecord.ReplaceOneAsync(x => x.Id == p.Id, p);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteProductType(string typeId)
    {
        try
        {
            _context.ProductTypeRecord.DeleteOne(x => x.Id == typeId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
