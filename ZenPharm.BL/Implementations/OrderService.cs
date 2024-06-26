﻿using Microsoft.EntityFrameworkCore;
using ZenPharm.BL.Interfaces;
using ZenPharm.DAL.Models;
using ZenPharm.DAL;

namespace ZenPharm.BL.Implementations;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _context;
    private readonly MockupEmail _mockup;
    private readonly IProductService _productService;

    public OrderService(ApplicationDbContext context,IProductService productService, MockupEmail mockup)
    {
        _context = context;
        _productService = productService;
        _mockup = mockup;
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return _context.Orders.ToList();
    }

    public Order GetOrderById(Guid id)
    {
        var ord = _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.OrderItemProduct).FirstOrDefault(o => o.ID == id);
        return ord;
    }

    public async Task AddOrder(Order order)
    {
        order.Placed = DateTime.Now;
        _context.Orders.Add(order);
        foreach (var item in order.OrderItems)
        {
            var prod = _productService.GetProductById(item.OrderItemProductID);
            prod.StockQuantity -= item.Quantity;
            _productService.UpdateProduct(prod);
        }
        _context.SaveChanges();
        var placedOrder = GetOrderById(order.ID);
        await _mockup.SendClientEmail(placedOrder);
        await _mockup.SendModeratorEmail(placedOrder);
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

    public PagedResult<Order> GetOrders(int page, int count)
    {
        var totalItems = _context.Orders.Count();
        var totalPages = (int)Math.Ceiling((double)totalItems / count);
        var orders = _context.Orders.Skip((page - 1) * count).Take(count).OrderByDescending(x=>x.Placed);
        var pageResult = new PagedResult<Order>(orders, totalPages, page, totalItems);
        return pageResult;
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
