using Microsoft.AspNetCore.Mvc;
using MvcOdev.Entities;
using MvcOdev.Models;
using MvcOdev.Services;
using System.Diagnostics;

namespace MvcOdev.Controllers
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


        public IActionResult VincSorusu()
        {
            VinctasimaForm vincTasiForm = new VinctasimaForm();
            return View(vincTasiForm);
        }

        [HttpPost]
        public IActionResult VincSorusu(VinctasimaForm vincTasiForm)
        {
            if (ModelState.IsValid)
            {
                vincTasiForm.KalanKg = VincTasimaHesapla.KayipKgBul(vincTasiForm.KacMetreGidecek, vincTasiForm.HerMetredeKayipKg, vincTasiForm.YuklenenKg);

            }
            return View(vincTasiForm);
        }



        public IActionResult KitapSayfa()
        {
            KitapSayfaForm kitapSayfaForm = new KitapSayfaForm();
            return View(kitapSayfaForm);
        }


        [HttpPost]
        public IActionResult KitapSayfa(KitapSayfaForm kitapSayfaForm)
        {
            if (ModelState.IsValid)
            {
                kitapSayfaForm.Gun = KitapSayfaHesapla.KalanSayfaHesapla(kitapSayfaForm.IlkGunOkunanSayfa, kitapSayfaForm.HerGunOkunanSayfasi, kitapSayfaForm.KitapSayfasi);

            }
            return View(kitapSayfaForm);
        }



        public IActionResult Iletisim()
        {
            return View();
        }

        public IActionResult BakimMaliyetHesabi()
        {
            BakimSorusu bakimSorusu = new BakimSorusu();
            return View(bakimSorusu);
        }

        [HttpPost]

        public IActionResult BakimMaliyetHesabi(BakimSorusu bakimbilgi)
        {
            if (ModelState.IsValid)
            {
                bakimbilgi.ToplamBakimSayisi = BakimSoru.Bakim(bakimbilgi.CalismaSuresi, bakimbilgi.BakimGunAraligi);

                bakimbilgi.ToplamBakimMaliyeti = BakimSoru.Maliyet(bakimbilgi.BakimMaliyeti, (double)bakimbilgi.ToplamBakimSayisi);
            }
            return View(bakimbilgi);
        }

        public IActionResult SinavNotOrtalamasi()
        {
            NotHesaplama notHesaplama=new NotHesaplama();
            return View(notHesaplama);
        }

		[HttpPost]
        public IActionResult SinavNotOrtalamasi(NotHesaplama notBilgisi)
        {
            if (ModelState.IsValid)
			{
                notBilgisi.Ortalama = NotHesaplaServices.OrtalamaHesapla(notBilgisi.Vize, notBilgisi.Final, notBilgisi.YüzdeFinal);

                if (notBilgisi.Ortalama > 55)
				{
                    notBilgisi.Durum = "GEÇTİ";
				}

                else if ( notBilgisi.Ortalama<45)
				{
                    notBilgisi.Durum = "KALDI";
				}

                else
				{
                    notBilgisi.Durum = "BÜTE KALDI";
				}
			}
            return View(notBilgisi);
        }

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}