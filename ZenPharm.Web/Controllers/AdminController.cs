using Microsoft.AspNetCore.Mvc;
using ZenPharm.BL.Interfaces;
using ZenPharm.DAL.Models;

namespace ZenPharm.Web.Controllers;

public class AdminController : Controller
{
    private readonly IProductService _productService;
    private readonly IOrderService _orderService;
    public AdminController(IProductService productService, IOrderService orderService)
    {
        _productService = productService;
        _orderService = orderService;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AdminProductList(int page = 1, int count= 10)
    {
        var prods = _productService.GetProducts(page, count).ToList();
        return View("AdminProductList", prods);
    }

    [HttpGet]
    public IActionResult AdminOrdersList(int page = 1, int count = 10)
    {
        //Random random = new Random();
        //var order = new Order()
        //{
        //    UserID = Guid.Parse("0f4bcfed-19cc-4236-becb-2918492750d8"),
        //    OrderItems = new List<OrderItem>()
        //    {
        //        new OrderItem() { OrderItemProductID = Guid.Parse("A3277C1C-DC6B-4C36-87E0-2496F0CDD007"), Quantity = random.Next(0,15)},
        //        new OrderItem() { OrderItemProductID = Guid.Parse("EFDB41B6-5A71-4AE8-9693-442EE889B1B5"), Quantity = random.Next(0,15)},
        //        new OrderItem() { OrderItemProductID = Guid.Parse("04F69ACA-69D3-494F-A5E5-F7CC5533F576"), Quantity = random.Next(0,15)},
        //    }
        //};
        //_orderService.AddOrder(order);
        var orders = _orderService.GetOrders(page, count).ToList();
        return View("AdminOrdersList", orders);
    }

    [HttpGet]
    public IActionResult OrderDetails(Guid ID)
    {
        var ord = _orderService.GetOrderById(ID);
        return View("OrderDetails", ord);
    }

    [HttpGet]
    public IActionResult AdminUserRoles()
    {
        return View("AdminUserRoles");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return PartialView("Register");
    }

    [HttpGet]
    public IActionResult Edit(Guid prodId)
    {
        var prod = _productService.GetProductById(prodId);
        return PartialView("Edit",prod);
    }
    
    [HttpGet]
    public IActionResult DeleteProd(Guid prodId)
    {
        return PartialView("DeleteProd", prodId);
    }



    //Posts from here

    [HttpPost]
    public IActionResult Register(Product product)
    {
        if (ModelState.IsValid)
        {
            _productService.AddProduct(product);
            return RedirectToAction("AdminProductList");
        }
        return View("RegisterProduct", product);
    }
    
    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            _productService.UpdateProduct(product);
            return RedirectToAction("AdminProductList");
        }
        return View("Edit", product);
    }
    
    [HttpPost]
    public IActionResult Delete(Guid prodId)
    {
        if (ModelState.IsValid)
        {
            _productService.DeleteProduct(prodId);
            return RedirectToAction("AdminProductList");
        }
        return View();
    }

    [HttpPost]
    public IActionResult CloseOrder(Guid id)
    {
        if (ModelState.IsValid)
        {
            _orderService.CloseOrder(id);
            return RedirectToAction("AdminOrdersList");
        }
        return View();
    }
}
