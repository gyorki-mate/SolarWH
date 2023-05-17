using SWH.Models;

namespace SWH.Interfaces;

public interface IProductType
{
    public Task<List<ProductType?>> GetAllProductTypes();
    public ProductType GetProductType(string typeId);
    public void AddProductType(ProductType? type);
    public void UpdateProductType(ProductType? type);
    public void DeleteProductType (string typeId);
}