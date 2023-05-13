using MongoDB.Driver;
using SWH.Interfaces;
using SWH.Models;

namespace SWH.Controllers;

public class CompartmentController : ICompartment
{
    private readonly DbContext _context = new();

    public async Task<List<Compartment>> GetAllCompartments()
    {
        try
        {
            var compartments = await _context.CompartmentRecord.Find(FilterDefinition<Compartment>.Empty).ToListAsync();
            //sort the shelves by row and column
            // shelves.Sort((x, y) => x.row.CompareTo(y.row) == 0 ? x.column.CompareTo(y.column) : x.row.CompareTo(y.row));
            
            return compartments;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Compartment GetCompartment(string compartmentId)
    {
        try
        {
            var compartment = _context.CompartmentRecord.Find(x => x.Id == compartmentId).FirstOrDefault();
            return compartment;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async void AddCompartment(Compartment compartment)
    {
        try
        {
            await _context.CompartmentRecord.InsertOneAsync(compartment);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<string> UpdateCompartment(Compartment compartment)
    {
        //TODO check if compartment is full
        //TODO set shelfid in product somewhere else (maybe in the frontend)
        // if (compartment.Shelves.Select(c => c.Product)
        //     .Any(product => product.Quantity > product.ProductType.MaxCapacity))
        // {
        //     return await Task.FromResult("Quantity is more than the max quantity");
        // }
        
        try
        {
            await _context.CompartmentRecord.ReplaceOneAsync(x => x.Id == compartment.Id, compartment);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return "";
    }

    public void DeleteCompartment(string compartmentId)
    {
        try
        {
            _context.CompartmentRecord.DeleteOne(x => x.Id == compartmentId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}