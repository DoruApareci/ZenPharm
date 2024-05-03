using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZenPharm.BL.Interfaces;
using ZenPharm.DAL.Models;
using ZenPharm.Web.Models;

namespace ZenPharm.Web.Controllers;

[Authorize]
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
    [Authorize(Roles = "Admin")]
    public IActionResult AdminProductList(int pageNumber = 1, int pageSize = 10)
    {
        var result = _productService.GetProducts(pageNumber, pageSize);

        AdminProductListViewModel adminViewModel = new();
        adminViewModel.CurrentPage = result.CurrentPage;
        adminViewModel.TotalPages = result.TotalPages;
        adminViewModel.Products = result.Value.ToList();

        return View("AdminProductList", adminViewModel);
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Moderator")]
    public IActionResult AdminOrdersList(int pageNumber = 1, int pageSize = 10)
    {
        var orders = _orderService.GetOrders(pageNumber, pageSize);
        AdminOrdersViewModel vm = new AdminOrdersViewModel();
        vm.CurrentPage = orders.CurrentPage;
        vm.TotalPages = orders.TotalPages;
        vm.Orders = orders.Value.ToList();
        return View("AdminOrdersList", vm);
    }

    [HttpGet]
    [Authorize(Roles = "Admin, Moderator")]
    public IActionResult OrderDetail(Guid ID)
    {
        var Order = _orderService.GetOrderById(ID);
        var Usr = _userManager.FindByIdAsync(Order.UserID.ToString()).Result;

        OrderDetailsViewModel model = new OrderDetailsViewModel()
        {
            Order = Order,
            Buyer = Usr
        };

        return View("OrderDetails", model);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminUserRoles()
    {
        var users = _userManager.Users.ToList();
        ViewBag.Roles = _roleManager.Roles.ToList();
        return View("AdminUserRoles", users);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Register()
    {
        return PartialView("Register");
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(Guid prodId)
    {
        var prod = _productService.GetProductById(prodId);
        return PartialView("Edit", prod);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteProd(Guid prodId)
    {
        return PartialView("DeleteProd", prodId);
    }

    //Posts from here

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Register(Product product)
    {
        if (ModelState.IsValid)
        {
            _productService.AddProduct(product);
            return RedirectToAction("AdminProductList");
        }
        return View("Register", product);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
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
    [Authorize(Roles = "Admin")]
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
    [Authorize(Roles = "Admin, Moderator")]
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
            return NotFound();
        var role = await _roleManager.FindByIdAsync(update.newRoleId);
        if (role == null)
            return NotFound();
        var userRoles = await _userManager.GetRolesAsync(user);
        var result = await _userManager.RemoveFromRolesAsync(user, userRoles);
        if (!result.Succeeded)
            return Ok(result);
        result = await _userManager.AddToRoleAsync(user, role.Name);
        if (!result.Succeeded)
            return BadRequest(result);
        return RedirectToAction("AdminUserRoles");
    }
}
