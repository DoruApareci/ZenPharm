using Microsoft.AspNetCore.Mvc;

namespace ZenPharm.Web.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
