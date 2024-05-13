using ZenPharm.BL.Interfaces;
using ZenPharm.DAL;
using ZenPharm.DAL.Models;

namespace ZenPharm.BL.Implementations;

public class ProdTypeService : IProdTypeService
{
    private readonly ApplicationDbContext _context;

    public ProdTypeService(ApplicationDbContext context)
    {
        _context = context;
    }
    public void AddProdType(ProductType ToAdd)
    {
        _context.ProductTypes.Add(ToAdd);
        _context.SaveChanges();
    }

    public ProductType GetProdType(Guid ID)
    {
        var ProdType = _context.ProductTypes.FirstOrDefault(t => t.ProdTypeID == ID);
        return ProdType;
    }

    public PagedResult<ProductType> GetProdTypes(int page, int count)
    {
        var totalItems = _context.ProductTypes.Count();
        var totalPages = (int)Math.Ceiling((double)totalItems / count);
        var types = _context.ProductTypes.Skip((page - 1) * count).Take(count);
        var pageResult = new PagedResult<ProductType>(types, totalPages, page, totalItems);
        return pageResult;
    }

    public IEnumerable<ProductType> GetProdTypes()
    {
        var ret = _context.ProductTypes.ToList();
        return ret;
    }

    public void RemoveProdType(Guid ID)
    {
        var prodType = _context.ProductTypes.FirstOrDefault(t => t.ProdTypeID == ID);
        if (prodType != null)
        {
            _context.Remove(prodType);
            _context.SaveChanges();
        }
    }
}
