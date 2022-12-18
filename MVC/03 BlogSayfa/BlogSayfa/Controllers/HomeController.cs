using BlogSayfa.Entities;
using BlogSayfa.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogSayfa.Controllers
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

            List<Slider> sliderlar = new List<Slider>
            {
                new Slider {Id=1,Baslik="Slider1",Aciklama="Slider1 Açıklaması Bu alana gelecek", Link="/Home/Hakkimizda",Resim="/Resimler/araba1.png"},
                new Slider{Id=2, Baslik="Slider2",Aciklama="Slider2 Aciklaması Bu alana gecelek",Resim="/Resimler/araba2.png" },
                new Slider{Id=3, Baslik="Slider3",Aciklama="Slider3 Aciklaması Bu alana gecelek",Link="https://sameterdem.com.tr/",Resim="/Resimler/araba3.png" },
            };


            List<Blog> bloglar = new List<Blog>
            {
                new Blog {Id=1,Resim="/Resimler/araba1.png",Etiket="Etiket Buraya Gelecek", Tarih="03.12.2022",Aciklama="Açıklama Bu alana  gelecek",Baslik="Baslik Bu alana gelecek" },
                 new Blog {Id=2,Resim="/Resimler/araba2.png",Etiket="Etiket Buraya Gelecek", Tarih="03.12.2022",Aciklama="Açıklama Bu alana  gelecek",Baslik="Baslik Bu alana gelecek" },
                  new Blog {Id=3,Resim="/Resimler/araba3.png",Etiket="Etiket Buraya Gelecek", Tarih="03.12.2022",Aciklama="Açıklama Bu alana  gelecek",Baslik="Baslik Bu alana gelecek" },
                  new Blog {Id=1,Resim="/Resimler/araba1.png",Etiket="Etiket Buraya Gelecek", Tarih="03.12.2022",Aciklama="Açıklama Bu alana  gelecek",Baslik="Baslik Bu alana gelecek" },
                 new Blog {Id=2,Resim="/Resimler/araba2.png",Etiket="Etiket Buraya Gelecek", Tarih="03.12.2022",Aciklama="Açıklama Bu alana  gelecek",Baslik="Baslik Bu alana gelecek" },
                  new Blog {Id=3,Resim="/Resimler/araba3.png",Etiket="Etiket Buraya Gelecek", Tarih="03.12.2022",Aciklama="Açıklama Bu alana  gelecek",Baslik="Baslik Bu alana gelecek" }

            };
            List<Hizmetler> hizmetler = new List<Hizmetler>
            {
                new Hizmetler {Id=1,HizmetAdi="Web Yazılım",Link="/Home/Galeri" },
                new Hizmetler {Id=2,HizmetAdi="Grafik Tasarım",Link="/Home/Galeri" },
                new Hizmetler {Id=3,HizmetAdi="SEO",Link="/Home/Galeri" }
            };
            

            var homeIndexViewModel = new HomeIndexViewModel
            {
                Sliderlar =  sliderlar,
                Bloglar = bloglar,
                Hizmetler = hizmetler

            };



            return View(homeIndexViewModel);
        }


        public IActionResult Hakkimizda()
        {
            List<Aile> aileUyeleri = new List<Aile>
            {
                new Aile {Id=1,AdiSoyadi="Emir Erce Akman", Yas=13, Telefon="05060939336", YakinlikDerecesi="Çocuk"},

                new Aile {Id=2,AdiSoyadi="Ümit Akman", Yas=42, Telefon="05060939336", YakinlikDerecesi="Baba"},

                new Aile {Id=3,AdiSoyadi="Bahar Akman", Yas=38, Telefon="05060939336", YakinlikDerecesi="Anne"}
            };
            var homeHakkimizdaViewModel = new HomeHakkimizdaViewModel
            {
                 AileUyeleri = aileUyeleri
            };
            return View(homeHakkimizdaViewModel);
        }
        public IActionResult Galeri()
        {
            List<Galeri> galeriResimleri = new List<Galeri>
            {
                new Galeri {Id=1,Resim="/Resimler/araba3.png"},
                new Galeri {Id=2,Resim="/Resimler/araba1.png"},
                new Galeri {Id=3,Resim="/Resimler/araba2.png"},
                new Galeri {Id=4,Resim="/Resimler/araba3.png"},
                new Galeri {Id=5,Resim="/Resimler/araba1.png"},
                new Galeri {Id=6,Resim="/Resimler/araba2.png"},
                new Galeri {Id=7,Resim="/Resimler/araba1.png"},
                new Galeri {Id=8,Resim="/Resimler/araba2.png"},
                new Galeri {Id=9,Resim="/Resimler/araba3.png"},
            };

            var homeGaleriViewModel = new HomeGaleriViewModel
            {
                galeriResimleri = galeriResimleri
            };
            return View(homeGaleriViewModel);
        }
        public IActionResult Iletisim()
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