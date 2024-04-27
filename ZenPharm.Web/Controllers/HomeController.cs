using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZenPharm.BL.Interfaces;
using ZenPharm.Web.Models;

namespace ZenPharm.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _prodServ;
        public HomeController(IProductService productService)
        {
            _prodServ = productService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
