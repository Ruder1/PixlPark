using Microsoft.AspNetCore.Mvc;
using PixlPark.Models;
using System.Diagnostics;

namespace PixlPark.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public string Index(string Email,string Message) => $"Email: {Email}\n Message: {Message}";
    }
}