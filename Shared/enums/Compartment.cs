using SWH.Models;

namespace SWH.Shared.enums;

public class Compartment
{
    public int id { get; set; }
    public List<Product> Products { get; set; } = new();
}