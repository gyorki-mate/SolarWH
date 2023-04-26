using SWH.Models;

namespace SWH.Shared.enums;

public class Shelf
{
    public int id { get; set; }
    public int shelfId { get; set; }
    public Product Product { get; set; } = new();
}