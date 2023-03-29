﻿using MongoDB.Driver;
using SWH.Interfaces;
using SWH.Models;

namespace SWH.Controllers;

public class ShelfController : IShelf
{
    DbContext context = new DbContext();

    public async Task<List<Shelf>> GetAllShelves()
    {
        try
        {
            var shelf = context.ShelfRecord.Find(FilterDefinition<Shelf>.Empty).ToListAsync();
            return await shelf;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Shelf GetShelf(string shelfID)
    {
        try
        {
            var Shelf = context.ShelfRecord.Find(x => x.id == shelfID).FirstOrDefault();
            return Shelf;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async void AddShelf(Shelf shelf)
    {
        if (shelf.Quantity > shelf.Product.MaxQuantity)
        {
            //throw exception, quantity is more than the maxquantity
            throw new Exception("Quantity is more than the max quantity");
        }

        try
        {
            await context.ShelfRecord.InsertOneAsync(shelf);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdateShelf(Shelf shelf)
    {
        throw new NotImplementedException();
    }

    public void DeleteShelf(string shelfID)
    {
        try
        {
            context.ShelfRecord.DeleteOne(x => x.id == shelfID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}