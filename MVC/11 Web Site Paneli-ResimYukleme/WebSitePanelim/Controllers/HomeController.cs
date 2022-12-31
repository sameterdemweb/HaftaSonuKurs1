using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebSitePanelim.Entities;
using WebSitePanelim.Models;

namespace WebSitePanelim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string ResimGetir()
        {
            if (HttpContext.Session.GetString("Resim") != null)
            {
                return HttpContext.Session.GetString("Resim").ToString();
            }
            else
            {
                return "ResimYok";
            }


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
    }
}