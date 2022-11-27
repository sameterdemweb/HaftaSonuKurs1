using Microsoft.AspNetCore.Mvc;
using MVCGiris.Entites;
using MVCGiris.Models;
using System.Diagnostics;

namespace MVCGiris.Controllers
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

        public IActionResult Galeri()
        {
            return View();
        }

        public IActionResult Iletisim()
        {
            return View();
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }

        public IActionResult Calisanlar()
        {

            List<Calisan> calisanlar = new List<Calisan>
            {
                new Calisan {Id=1,Adi="Samet",Soyadi="Erdem",Yas=30, Maas=17900},
                new Calisan {Id=1,Adi="Mehmet",Soyadi="Ulusoy",Yas=24, Maas=5000},
                new Calisan {Id=1,Adi="Erce",Soyadi="Akman",Yas=15, Maas=600},
                new Calisan {Id=1,Adi="İlker",Soyadi="Ulaş",Yas=20, Maas=2000},
            };

            List<string> hizmetlerimiz = new List<string> { "Web Tasarım", "Web Yazılım", "SEO", "Kurumsal Kimlik" };


            var calisanListModel = new CalisanListModel
            {
                Calisanlar = calisanlar,
                Hizmetlerimiz = hizmetlerimiz
            };

            return View(calisanListModel);
        }

        public string MerhabaDe()
        {
            return "Merhaba Dünyalı biz dostuz.";
        }


        public IActionResult Ornek1() // ActionResult türünde nesneler döndürebiliriz. Yapılan istekde bir sıkıntı olmadığında 200 geri döndürürüz.
        {
            return StatusCode(200);
           return Ok() ;
        }

        public IActionResult Ornek2() // ActionResult türünde nesneler döndürebiliriz. Yapılan istekte Bad request 400 hatası verdirdik. Sayfa kaynağını görüntülediğimizde görebiliriz.
        {
            return StatusCode(400);
            //return BadRequest();
        }

        public IActionResult Ornek3() // ActionResult türünde nesneler döndürebiliriz. Yapılan istekte Bad request 404 hatası verdirdik. Sayfa bulunmadı hatası. Sayfa kaynağını görüntülediğimizde görebiliriz.
        {
            return StatusCode(404);
            //return NotFound();
        }


        public StatusCodeResult Ornek4() // Durum kodu göndereceğimiz belirtiriz.
        {
            return StatusCode(404);
            //return NotFound();
        }

        public RedirectResult Ornek5() // Bir aksiyon sonucunda başka bir linke yönlendirme işleminde kullanılır. Örneğin veritabanına bir kayıt eklendiğinde ana sayfaya dönülecek ise RedirectResult tan yararlanabiliriz.
        {

            return Redirect("https://www.sameterdem.com.tr");

        }

        public IActionResult Ornek6() // Bir aksiyon sonucunda başka bir aksiyona yönlendirme işleminde kullanılır. Örneğin veritabanına bir kayıt eklendiğinde ana sayfaya dönülecek ise IActionResult tan yararlanabiliriz.
        {
            return RedirectToAction("Ornek4");
        }


        public ViewResult RazorDemo() // Razor syntaxı ile html sayfasında kullanım örnekleri.
        {
            return View();
        }

        //Querystringten Değer Döndürme
        public string QuerystringDegerDondur(string id)
        {
            return Convert.ToString(id);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}