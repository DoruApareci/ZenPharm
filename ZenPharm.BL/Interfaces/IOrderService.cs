using ZenPharm.DAL.Models;

namespace ZenPharm.BL.Interfaces;

public interface IOrderService
{
    IEnumerable<Order> GetAllOrders();
    PagedResult<Order> GetOrders(int page, int count);
    Order GetOrderById(Guid id);
    Task AddOrder(Order order);
    void CloseOrder(Guid id);
    void UpdateOrder(Order order);
    void DeleteOrder(Guid id);
}
