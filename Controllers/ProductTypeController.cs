using SWH.Models;
using SWH.Interfaces;
using MongoDB.Driver;
namespace SWH.Controllers;

public class ProductTypeController: IProductType
{
    DbContext context = new DbContext();
    public async Task<List<ProductType>> GetAllProductTypes()
    {
        try
        {
            var types = context.ProductTypeRecord.Find(FilterDefinition<ProductType>.Empty).ToListAsync();
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
        throw new NotImplementedException();
    }

    public async void AddProductType(ProductType type)
    {
        try
        {
            await context.ProductTypeRecord.InsertOneAsync(type);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async void UpdateProductType(ProductType type)
    {
        try
        {
             await context.ProductTypeRecord.ReplaceOneAsync(x => x.id == type.id, type);
            //populate the product type
            var productList =  await context.ProductRecord.Find(x => x.ProductType.id == type.id).ToListAsync();
            foreach (var p in productList)
            {
                p.ProductType = type;
                context.ProductRecord.ReplaceOneAsync(x => x.Id == p.Id, p);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteProductType(string typeID)
    {
        try
        {
            context.ProductTypeRecord.DeleteOne(x => x.id == typeID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}