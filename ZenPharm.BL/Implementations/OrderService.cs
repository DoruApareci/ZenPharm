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
        return _context.Orders.Find(id);
    }

    public void AddOrder(Order order)
    {
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
}
