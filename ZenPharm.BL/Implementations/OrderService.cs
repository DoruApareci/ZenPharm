using Microsoft.EntityFrameworkCore;
using ZenPharm.BL.Interfaces;
using ZenPharm.DAL.Models;
using ZenPharm.DAL;

namespace ZenPharm.BL.Implementations;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _context;

    public OrderService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return _context.Orders.ToList();
    }

    public Order GetOrderById(Guid id)
    {
        var ord = _context.Orders.Include(o => o.OrderItems).FirstOrDefault(o => o.ID == id);
        return ord;
    }

    public void AddOrder(Order order)
    {
        order.Placed = DateTime.Now;
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void UpdateOrder(Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteOrder(Guid id)
    {
        var order = _context.Orders.Find(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Order> GetOrders(int page, int count)
    {
        var orders = _context.Orders.Skip((page-1)*count).Take(count);
        return orders;
    }

    public void CloseOrder(Guid id)
    {
        var order = GetOrderById(id);
        if (order != null)
        {
            order.Status = DAL.Models.Enums.OrderStatus.Close;
            _context.SaveChanges();
        }
    }
}
