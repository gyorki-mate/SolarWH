﻿using MongoDB.Driver;
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
        try
        {
            var column = context.ColumnRecord.Find(x => x.id == columnID).FirstOrDefault();
            return column;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
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
        try
        {
            context.ColumnRecord.DeleteOne(x => x.id == column.id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteColumn(string columnID)
    {
        try
        {
            context.ColumnRecord.DeleteOne(x => x.id == columnID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}