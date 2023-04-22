using SWH.Models;

namespace SWH.Interfaces;

public interface IProduct
{
    public Task<List<Product>> GetAllProducts();
    public Product GetProduct(string productID);
    public void AddProduct(Product product, string productTypeID);
    public void UpdateProduct(Product product);
    public void DeleteProduct(string productID);
}