using AdminPanel.Identity;
using AdminPanel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdminPanel.Controllers
{
    [Authorize(Roles = "Admin")]// Class tepesine koyarsak bunu tüm mehodlarda kullanıcı girişi ister.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly AdminPanelContext _context;

        public HomeController(ILogger<HomeController> logger, AdminPanelContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeDashboardViewModel homeDashboardViewModel = new HomeDashboardViewModel
            {
                SatisAdet = _context.Siparisler.Where(s=>s.SiparisDurumu== "Ödeme Yapıldı").Count(),
                KargodaAdet = _context.Siparisler.Where(s=>s.SiparisDurumu== "Kargoda").Count(),
                TamamlananAdet = _context.Siparisler.Where(s=>s.SiparisDurumu== "Tamamlandı").Count(),
                IptalAdet = _context.Siparisler.Where(s=>s.SiparisDurumu== "İptal").Count(),
                ToplamSiparis = _context.Siparisler.Count(),
                UrunAdet = _context.Urunler.Where(u => u.Durum == 1).Count(),
                UrunFotograflari = _context.UrunFotograflari.Where(u=>u.Durum==1).Count(),
                UyelerAdet = _context.AppIdentityUser.Where(u=>u.AdminMi!=1).Count(),
            };
            return View(homeDashboardViewModel);
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