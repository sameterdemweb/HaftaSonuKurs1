using HastaneProje.Identity;
using HastaneProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace HastaneProje.Controllers
{
    [Authorize(Roles = "Başhekim,Doktorlar,Sekreter")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppIdentityDbContext _context;


        public HomeController(AppIdentityDbContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            AnaSayfaRaporlari raporBilgi = new();
            raporBilgi.UyeSayisi = _context.IdentityUser.Count();
            raporBilgi.RandevuSayisi = _context.Randevular.Count();
            raporBilgi.GelirToplam = _context.HastaneKasaGelir.Sum(g=>g.Ucret);
            raporBilgi.GiderToplam = _context.HastaneKasaGider.Sum(g=>g.Ucret);
            raporBilgi.KarBilgisi = raporBilgi.GelirToplam - raporBilgi.GiderToplam;

            return View(raporBilgi);
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