using Microsoft.AspNetCore.Mvc;

namespace ZenPharm.Web.Controllers;

public class OrdersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
