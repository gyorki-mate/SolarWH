using MongoDB.Driver;
using SWH.Interfaces;
using SWH.Models;

namespace SWH.Controllers;

public class ColumnController : IColumn
{
    DbContext context = new DbContext();

    public async Task<List<Column>> GetAllColumns()
    {
        try
        {
            var columns = context.ColumnRecord.Find(FilterDefinition<Column>.Empty).ToListAsync();
            return await columns;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Column GetColumn(string columnID)
    {
        throw new NotImplementedException();
    }

    public async void AddColumn(Column column)
    {
        try
        {
            await context.ColumnRecord.InsertOneAsync(column);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdateColumn(Column column)
    {
        throw new NotImplementedException();
    }

    public void DeleteColumn(string columnID)
    {
        throw new NotImplementedException();
    }
}