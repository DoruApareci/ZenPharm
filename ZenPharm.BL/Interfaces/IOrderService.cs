using ZenPharm.DAL.Models;

namespace ZenPharm.BL.Interfaces;

public interface IOrderService
{
    IEnumerable<Order> GetAllOrders();
    Order GetOrderById(Guid id);
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    void DeleteOrder(Guid id);
}
