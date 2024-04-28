using Microsoft.AspNetCore.Mvc;
using ZenPharm.BL.Interfaces;
using ZenPharm.DAL.Models;

namespace ZenPharm.Web.Controllers;

public class AdminController : Controller
{
    private readonly IProductService _productService;
    public AdminController(IProductService productService)
    {
        _productService = productService;
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
    public IActionResult AdminOrdersList()
    {
        return View("AdminOrdersList");
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
}
