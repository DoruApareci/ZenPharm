using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZenPharm.BL.Interfaces;
using ZenPharm.Web.Models;

namespace ZenPharm.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _prodServ;
        private readonly IFeedbackService _feedbackService;
        public HomeController(IProductService productService, IFeedbackService feedbackService)
        {
            _prodServ = productService;
            _feedbackService = feedbackService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Feedback([FromForm]FeedbackFormViewModel message)
        {
            if (ModelState.IsValid)
            {
                _feedbackService.PlaceFeedback(message.ClientFeedBack);
            }
            return Redirect("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
