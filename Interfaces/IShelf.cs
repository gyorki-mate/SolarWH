using SWH.Models;

namespace SWH.Interfaces;

public interface IShelf
{
    public Task<List<Shelf>> GetAllShelves();
    public Shelf GetShelf(string shelfID);
    public Task<string?> AddShelf(Shelf shelf);
    public Task<string>? UpdateShelf(Shelf shelf);
    public void DeleteShelf(string shelfID);
}