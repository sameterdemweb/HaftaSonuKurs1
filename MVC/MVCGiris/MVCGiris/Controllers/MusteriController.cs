using Microsoft.AspNetCore.Mvc;

namespace MVCGiris.Controllers
{
    public class MusteriController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MusteriEkle() {
            return View();
        }
        public IActionResult MusteriDuzenle()
        {
            return View();
        }

    }
}
