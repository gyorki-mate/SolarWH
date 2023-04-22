using MongoDB.Driver;
using SWH.Interfaces;
using SWH.Models;

namespace SWH.Controllers;

public class ShelfController : IShelf
{
    private readonly DbContext _context = new();

    public async Task<List<Shelf>> GetAllShelves()
    {
        try
        {
            var shelves = await _context.ShelfRecord.Find(FilterDefinition<Shelf>.Empty).ToListAsync();
            //sort the shelves by row and column
            shelves.Sort((x, y) => x.row.CompareTo(y.row) == 0 ? x.column.CompareTo(y.column) : x.row.CompareTo(y.row));
            return shelves;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Shelf GetShelf(string shelfId)
    {
        try
        {
            var shelf = _context.ShelfRecord.Find(x => x.id == shelfId).FirstOrDefault();
            return shelf;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async void AddShelf(Shelf shelf)
    {
        // if (shelf.Quantity > shelf.Product.MaxQuantity)
        // {
        //     //throw exception, quantity is more than the maxquantity
        //     throw new Exception("Quantity is more than the max quantity");
        // }
//TODO check if compartment is full

        try
        {
            await _context.ShelfRecord.InsertOneAsync(shelf);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdateShelf(Shelf shelf)
    {
        //TODO check if compartment is full

        try
        {
            _context.ShelfRecord.ReplaceOne(x => x.id == shelf.id, shelf);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteShelf(string shelfID)
    {
        try
        {
            _context.ShelfRecord.DeleteOne(x => x.id == shelfID);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}