using SWH.Models;

namespace SWH.Interfaces;

public interface IProduct
{
    public Task<List<Product>> GetAllProducts();
    public Task<List<Product>> GetAllNonStoredProducts();
    public Product GetProduct(string productID);
    public Product? AddProduct(Product product, string productTypeID);
    public void UpdateProduct(Product product);
    public void DeleteProduct(string productID);
}
