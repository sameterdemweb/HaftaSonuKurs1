using Microsoft.AspNetCore.Mvc;
using Office.Entities;
using Office.Models;
using Office.Services;
using System.Diagnostics;

namespace Office.Controllers
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
        public IActionResult Hakkimizda()
        {
            return View();
        }
        public IActionResult Ofisler()
        {
            return View();
        }
        public IActionResult Iletisim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Iletisim(IletisimForm iletisimForm)
        {
            if (ModelState.IsValid) {
                string icerik = "İletişim Formundan formu doldurarak gönderilen değerler:<br/><br/>" +
                    "Mesaj Gönderenin Adı:" + iletisimForm.AdSoyad + "<br/>" +
                    "Mesaj Gönderenin Telefonu:" + iletisimForm.Telefon + "<br/>" +
                    "Mesaj Gönderenin Konu:" + iletisimForm.Konu + "<br/>" +
                    "Mesaj Gönderenin Mesaj:" + iletisimForm.Mesaj + "<br/>" +
                    "Mesaj Gönderenin Mail Adresi:" + iletisimForm.Mail + "<br/>" +
                    "Bilgileri ile Kullanıcıya dönüş yapabilirsiniz.";
                string konu = iletisimForm.Konu;
                string gidecekMail = "m.ulusoyyyy@gmail.com";
                MailIslemleri.MailGonderme(icerik, konu, gidecekMail);
                ViewBag.MailGonderim = true;
            }
            return View();
        }
        public IActionResult ToplantiOdalari()
        {
            return View();
        }
        public IActionResult Urunler()
        {
            UrunlerForm urun = new UrunlerForm();

            return View(urun);
        }
        [HttpPost]
        public IActionResult Urunler(UrunlerForm urun)
        {
            FiyatHesapla fiyatHesapla = new FiyatHesapla();

            urun.UrunVergiFiyat = fiyatHesapla.KDVHesap(urun.UrunFiyat, urun.UrunVergi);
            urun.GenelToplam = fiyatHesapla.GenelToplamHesapla(urun.UrunAdet, urun.UrunFiyat, urun.UrunVergiFiyat);

            return View(urun);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}