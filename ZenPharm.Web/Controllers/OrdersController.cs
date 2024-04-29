using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZenPharm.BL.Interfaces;
using ZenPharm.DAL.Models;
using ZenPharm.Web.Models;

namespace ZenPharm.Web.Controllers;

public class OrdersController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;
    public OrdersController(IOrderService orderService, IProductService productService)
    {
        _orderService = orderService;
        _productService = productService;
    }

    [HttpPost]
    [Authorize]
    public IActionResult PlaceOrder([FromBody] OrderItemsViewModel order)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!(!string.IsNullOrEmpty(userId) && Guid.TryParse(userId, out var userIdGuid)))
            return BadRequest("Invalid user ID.");

        var newOrder = new Order
        {
            UserID = userIdGuid,
            OrderItems = order.OrderItems.Select(x =>
                new OrderItem
                {
                    OrderItemProductID = x.Item1,
                    Quantity = x.Item2
                }).ToList()
        };
        _orderService.AddOrder(newOrder);
        return Ok("Order placed successfully!");
    }

    //needs refactoring(prodId is null on every request)
    [HttpGet]
    public Product ProdDetails(Guid prodId)
    {
        var prod = _productService.GetProductById(prodId);
        return prod;
    }
}
