using SWH.Models;
using SWH.Interfaces;
using MongoDB.Driver;

namespace SWH.Controllers;

public class RowController : IRow
{
    DbContext context = new DbContext();

    public async Task<List<Row>> GetAllRows()
    {
        try
        {
            var row = context.RowRecord.Find(FilterDefinition<Row>.Empty).ToListAsync();
            return await row;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Row GetRow(string rowID)
    {
        try
        {
            var row = context.RowRecord.Find(x => x.id == rowID).FirstOrDefault();
            return row;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async void AddRow(Row row)
    {
        try
        {
            await context.RowRecord.InsertOneAsync(row);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdateRow(Row row)
    {
        try
        {
            context.RowRecord.DeleteOne(x => x.id == row.id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteRow(string rowID)
    {
        try
        {
            context.RowRecord.DeleteOne(x => x.id == rowID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}