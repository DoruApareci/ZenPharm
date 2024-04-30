using ZenPharm.DAL.Models;

namespace ZenPharm.BL.Interfaces;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    PagedResult<Product> GetProducts(int page, int count);
    Product GetProductById(Guid id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Guid id);
}
