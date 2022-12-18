using Microsoft.AspNetCore.Mvc;
using MvcOdev.Entities;
using MvcOdev.Services;

namespace MvcOdev.Controllers
{
	public class AracController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult OtoparkDurumu(Otopark otoparkBilgileri)
		{
			otoparkBilgileri.KalanArac = OtoparkServices.KalanAracBulma(otoparkBilgileri.MevcutArac, otoparkBilgileri.GirenArac, otoparkBilgileri.CikanArac, otoparkBilgileri.Saat);
			return View(otoparkBilgileri);
		}
	}
}
