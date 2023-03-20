using SWH.Models;
using SWH.Interfaces;
using MongoDB.Driver;
namespace SWH.Controllers;

public class WarehouseController : IWarehouse
{
    DbContext context = new DbContext();

    public async Task<List<Warehouse>> GetAllRows()
    {
        try
        {
            var rows = context.WarehouseRecord.Find(FilterDefinition<Warehouse>.Empty).ToListAsync();
            return await rows;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

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

    public void AddRow(Warehouse wh)
    {
        throw new NotImplementedException();
    }

    public void UpdateRow(Warehouse wh)
    {
        throw new NotImplementedException();
    }

    public void DeleteRow(string whID)
    {
        throw new NotImplementedException();
    }
}