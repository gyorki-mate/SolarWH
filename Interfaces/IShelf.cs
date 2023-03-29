using SWH.Models;

namespace SWH.Interfaces;

public interface IShelf
{
    public Task<List<Shelf>> GetAllShelves();
    public Shelf GetShelf(string shelfID);
    public void AddShelf(Shelf shelf);
    public void UpdateShelf(Shelf shelf);
    public void DeleteShelf(string shelfID);
}