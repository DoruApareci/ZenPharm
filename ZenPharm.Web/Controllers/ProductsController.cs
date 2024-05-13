using Microsoft.AspNetCore.Mvc;
using ZenPharm.BL.Interfaces;
using ZenPharm.DAL.Models;
using ZenPharm.Web.Models;

namespace ZenPharm.Web.Controllers;

public class ProductsController(IProductService productService) : Controller
{
    private readonly IProductService _productService = productService;

    public IActionResult Products(int pageNumber = 1, int pageSize = 12, string searchKey = "", string? typeID = "")
    {
        PagedResult<Product> products = (string.IsNullOrEmpty(searchKey) && string.IsNullOrEmpty(typeID)) ?
         _productService.GetProducts(pageNumber, pageSize) :
         _productService.GetProducts(pageNumber, pageSize, searchKey, typeID);

        var productsViewModel = new ProductsViewModel();
        productsViewModel.ProductTypes = _productService.GetProductTypesWithCount().ToList();
        productsViewModel.CurrentPage = products.CurrentPage;
        productsViewModel.TotalPages = products.TotalPages;
        productsViewModel.Products = products.Value.ToList();

        return View(productsViewModel);
    }

    public IActionResult ProductDetails(Guid productId)
    {
        var productViewModel = new ProductViewModel();
        var product = _productService.GetProductById(productId);
        productViewModel.Product = product;
        return View(productViewModel);
    }

    public IActionResult ShoppingCart()
    {
        return View();
    }
}
