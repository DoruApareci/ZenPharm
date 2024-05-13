using ZenPharm.BL.Interfaces;
using ZenPharm.DAL;
using ZenPharm.DAL.Models;

namespace ZenPharm.BL.Implementations;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;
    private readonly IImageService _imageService;
    private readonly IProdTypeService _productTypeService;

    public ProductService(ApplicationDbContext context, IImageService imageService, IProdTypeService productTypeService)
    {
        _context = context;
        _imageService = imageService;
        _productTypeService = productTypeService;
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
        var existingProduct = GetProductById(product.Id);
        if (existingProduct == null)
        {
            return;
        }
        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.StockQuantity = product.StockQuantity;
        existingProduct.Price = product.Price;
        existingProduct.ExpiryDate = product.ExpiryDate;
        existingProduct.ProdTypeID = product.ProdTypeID;
        if (product.FormFile != null)
        {
            _imageService.DeletePhoto(existingProduct.PubId);
            var resp = _imageService.AddPhoto(product.FormFile);
            existingProduct.Path = resp.Url.ToString();
            existingProduct.PubId = resp.PublicId;
        }
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

    public PagedResult<Product> GetProducts(int page, int count)
    {
        var totalItems = _context.Products.Count();
        var totalPages = (int)Math.Ceiling((double)totalItems / count);
        var prods = _context.Products.Skip((page - 1) * count).Take(count);
        var pageResult = new PagedResult<Product>(prods, totalPages, page, totalItems);
        return pageResult;
    }

    public PagedResult<Product> GetProducts(int page, int count, string? key, string? catid)
    {
        IQueryable<Product> query = _context.Products;
        if (!string.IsNullOrEmpty(key))
        {
            query = query.Where(x => x.Name.ToLower().Contains(key.ToLower()));
        }
        if (!string.IsNullOrEmpty(catid))
        {
            query = query.Where(x => x.ProdTypeID == Guid.Parse(catid));
        }

        var totalItems = query.Count();
        var totalPages = (int)Math.Ceiling((double)totalItems / count);
        
        var prods = query.Skip((page - 1) * count).Take(count).ToList();

        var pageResult = new PagedResult<Product>(prods, totalPages, page, totalItems);
        return pageResult;
    }

    public IEnumerable<Tuple<ProductType, int>> GetProductTypesWithCount()
    {
        var ret = new List<Tuple<ProductType, int>>();
        var prodTypes = _productTypeService.GetProdTypes().ToList();
        foreach (var item in prodTypes)
        {
            ret.Add(new Tuple<ProductType, int>(item, _context.Products.Count(x => x.ProdTypeID == item.ProdTypeID)));
        }
        return ret;
    }
}
