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
    public async Task<IActionResult> PlaceOrder([FromBody] OrderItemsViewModel order)
    {
        if (!ModelState.IsValid)
            return await Task.FromResult(BadRequest(ModelState));

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!(!string.IsNullOrEmpty(userId) && Guid.TryParse(userId, out var userIdGuid)))
            return await Task.FromResult(BadRequest("Invalid user ID."));

        var newOrder = new Order
        {
            UserID = userIdGuid,
            OrderItems = order.OrderItems.Select(x =>
                new OrderItem
                {
                    OrderItemProductID = x.ProdId,
                    Quantity = x.Quantity
                }).ToList()
        };
        await _orderService.AddOrder(newOrder);
        return Ok("Order placed successfully!");
    }

    public Product ProdDetails([FromQuery] Guid prodId)
    {
        var prod = _productService.GetProductById(prodId);
        return prod;
    }
}
