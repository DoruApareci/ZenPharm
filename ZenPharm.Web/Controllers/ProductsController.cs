using Microsoft.AspNetCore.Mvc;
using ZenPharm.BL.Interfaces;
using ZenPharm.Web.Models;

namespace ZenPharm.Web.Controllers;

public class ProductsController(IProductService productService) : Controller
{
    private readonly IProductService _productService = productService;

    public IActionResult Products()
    {
        var products = _productService.GetAllProducts();
        var productsViewModel = new ProductsViewModel();
        productsViewModel.Products = products;
        return View(productsViewModel);
    }

    public IActionResult ProductDetails(Guid productId)
    {
        var productViewModel = new ProductViewModel();
        var product = _productService.GetProductById(productId);
        productViewModel.Product = product;
        return View(productViewModel);
    }
}
