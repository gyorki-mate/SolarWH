using SWH.Models;

namespace SWH.Shared.enums;

public class Shelf
{
    public int Id { get; /*set;*/ }
    public int ShelfId { get; set; }
    public Product? Product { get; set; } = new();
}
