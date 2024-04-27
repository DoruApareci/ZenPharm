using ZenPharm.DAL.Models;

namespace ZenPharm.Web.Models;

public class ProductsViewModel
{
    public IEnumerable<Product> Products { get; set; } = [];
}
