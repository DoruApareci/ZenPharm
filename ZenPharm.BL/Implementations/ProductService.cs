using Microsoft.EntityFrameworkCore;
using ZenPharm.BL.Interfaces;
using ZenPharm.DAL;
using ZenPharm.DAL.Models;

namespace ZenPharm.BL.Implementations;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;
    private readonly IImageService _imageService;

    public ProductService(ApplicationDbContext context, IImageService imageService)
    {
        _context = context;
        _imageService = imageService;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }

    public Product GetProductById(Guid id)
    {
        return _context.Products.Find(id);
    }

    public void AddProduct(Product product)
    {
        var resp = _imageService.AddPhoto(product.FormFile);
        product.Path = resp.Url.ToString();
        product.PubId = resp.PublicId;
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        var toUpdate = GetProductById(product.Id);
        if (product.FormFile != null)
        {
            _imageService.DeletePhoto(toUpdate.PubId);
            var resp = _imageService.AddPhoto(product.FormFile);
            product.Path = resp.Url.ToString();
            product.PubId = resp.PublicId;
        }
        _context.Entry(product).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteProduct(Guid id)
    {
        var product = _context.Products.Find(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Product> GetProducts(int page, int count)
    {
        var prods = _context.Products.Skip((page-1)*count).Take(count);
        return prods;
    }
}
