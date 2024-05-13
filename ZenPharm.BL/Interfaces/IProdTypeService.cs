using ZenPharm.DAL.Models;

namespace ZenPharm.BL.Interfaces;

public interface IProdTypeService
{
    public void AddProdType(ProductType ToAdd);
    public void RemoveProdType(Guid ID);
    public ProductType GetProdType(Guid ID);
    public PagedResult<ProductType> GetProdTypes(int page, int count);
    public IEnumerable<ProductType> GetProdTypes();

}
