using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZenPharm.BL.Interfaces;
using ZenPharm.DAL.Models;
using ZenPharm.Web.Models;

namespace ZenPharm.Web.Controllers;

public class AdminController : Controller
{
    private readonly IProductService _productService;
    private readonly IOrderService _orderService;

    private readonly UserManager<ZenPharmUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminController(IProductService productService, 
                            IOrderService orderService, 
                            UserManager<ZenPharmUser> userManager, 
                            RoleManager<IdentityRole> roleManager)
    {
        _productService = productService;
        _orderService = orderService;
        _userManager = userManager;
        _roleManager = roleManager;
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
        var users = _userManager.Users.ToList();
        ViewBag.Roles = _roleManager.Roles.ToList();
        return View("AdminUserRoles", users);
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

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleViewModel update)
    {
        var user = await _userManager.FindByIdAsync(update.userId);
        if (user == null)
        {
            return NotFound();
        }

        var role = await _roleManager.FindByIdAsync(update.newRoleId);
        if (role == null)
        {
            return NotFound();
        }

        var userRoles = await _userManager.GetRolesAsync(user);
        var result = await _userManager.RemoveFromRolesAsync(user, userRoles);
        if (!result.Succeeded)
        {
            return Ok(result);
        }

        result = await _userManager.AddToRoleAsync(user, role.Name);
        if (!result.Succeeded)
        {
            return BadRequest(result);
        }

        return RedirectToAction("AdminUserRoles");
    }
}
