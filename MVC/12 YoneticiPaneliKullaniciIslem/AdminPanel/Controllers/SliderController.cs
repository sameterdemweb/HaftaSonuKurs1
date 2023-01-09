using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminPanel.Entities;
using AdminPanel.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AdminPanel.Controllers
{
    [Authorize(Roles = "Admin")]// Class tepesine koyarsak bunu tüm mehodlarda kullanıcı girişi ister.
    public class SliderController : Controller
    {

        private readonly AdminPanelContext _context;
        private readonly IWebHostEnvironment _host; //IWebHostEnvironment www root için hosting kütüphanesini entegre ettik.

        public SliderController(AdminPanelContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }

        // GET: Slider
        public async Task<IActionResult> Index()
        {
              return _context.Slider != null ? 
                          View(await _context.Slider.ToListAsync()) :
                          Problem("Entity set 'AdminPanelContext.Slider'  is null.");
        }

        // GET: Slider/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Slider == null)
            {
                return NotFound();
            }

            var slider = await _context.Slider
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // GET: Slider/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Slider/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Aciklama,Link,Durum,ResimDosya,MobilResimDosya")] Slider slider)
        {
            if (ModelState.IsValid)
            {
                if (slider.ResimDosya != null)
                {


                    // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                    string wwwRootPath = _host.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(slider.ResimDosya.FileName);//Dosya Adını Aldık.
                    string extension = Path.GetExtension(slider.ResimDosya.FileName);//Yüklenen Resmin Uzantısını Aldık.
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath, "YuklenenResimler/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await slider.ResimDosya.CopyToAsync(fileStream);
                    }

                    slider.Resim = fileName;
                }
                // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi


                if (slider.MobilResimDosya != null)
                {
                    // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                    string wwwRootPath2 = _host.WebRootPath;
                    string fileName2 = Path.GetFileNameWithoutExtension(slider.MobilResimDosya.FileName);//Dosya Adını Aldık.
                    string extension2 = Path.GetExtension(slider.MobilResimDosya.FileName);//Yüklenen Resmin Uzantısını Aldık.
                    fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;
                    string path = Path.Combine(wwwRootPath2, "YuklenenResimler/", fileName2);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await slider.MobilResimDosya.CopyToAsync(fileStream);
                    }

                    slider.MobilResim = fileName2;
                }
                // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi

                _context.Add(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        // GET: Slider/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Slider == null)
            {
                return NotFound();
            }

            var slider = await _context.Slider.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }
            if (slider.Resim != null)
            {
                HttpContext.Session.SetString("Resim", slider.Resim);
            }
            if (slider.MobilResim != null)
            {
                HttpContext.Session.SetString("MobilResim", slider.MobilResim);
            }

            return View(slider);
        }

        // POST: Slider/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Aciklama,Link,Durum,ResimDosya,MobilResimDosya")] Slider slider)
        {
            if (id != slider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (slider.ResimDosya != null)
                    {
                        // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                        string wwwRootPath = _host.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(slider.ResimDosya.FileName);//Dosya Adını Aldık.
                        string extension = Path.GetExtension(slider.ResimDosya.FileName);//Yüklenen Resmin Uzantısını Aldık.
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath, "YuklenenResimler/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await slider.ResimDosya.CopyToAsync(fileStream);
                        }

                        slider.Resim = fileName;
                    }
                    else if (HttpContext.Session.GetString("Resim") != null)
                    {
                        slider.Resim = HttpContext.Session.GetString("Resim");
                    }


                    if (slider.MobilResimDosya != null)
                    {
                        // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                        string wwwRootPath2 = _host.WebRootPath;
                        string fileName2 = Path.GetFileNameWithoutExtension(slider.MobilResimDosya.FileName);//Dosya Adını Aldık.
                        string extension2 = Path.GetExtension(slider.MobilResimDosya.FileName);//Yüklenen Resmin Uzantısını Aldık.
                        fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;
                        string path = Path.Combine(wwwRootPath2, "YuklenenResimler/", fileName2);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await slider.MobilResimDosya.CopyToAsync(fileStream);
                        }

                        slider.MobilResim = fileName2;
                    }
                    else if (HttpContext.Session.GetString("MobilResim") != null)
                    {
                        slider.MobilResim = HttpContext.Session.GetString("MobilResim");
                    }


                    _context.Update(slider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderExists(slider.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        // GET: Slider/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Slider == null)
            {
                return NotFound();
            }

            var slider = await _context.Slider
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // POST: Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Slider == null)
            {
                return Problem("Entity set 'AdminPanelContext.Slider'  is null.");
            }
            var slider = await _context.Slider.FindAsync(id);
            if (slider != null)
            {

                //Resim Silindiyse Klasör içerisinden de sildireceğiz. Kök dizin klasöründen de silinecek.
                var resimYolu = Path.Combine(_host.WebRootPath, "YuklenenResimler", slider.Resim);
                if (System.IO.File.Exists(resimYolu))//Bu belirlenen yolda bir dosya var mı?
                {
                    System.IO.File.Delete(resimYolu);//Buyoldaki dosyayı sil
                }
                //Resim Silindiyse Klasör içerisinden de sildireceğiz.

                //Resim Silindiyse Klasör içerisinden de sildireceğiz. Kök dizin klasöründen de silinecek.
                var resimYolu2 = Path.Combine(_host.WebRootPath, "YuklenenResimler", slider.MobilResim);
                if (System.IO.File.Exists(resimYolu2))//Bu belirlenen yolda bir dosya var mı?
                {
                    System.IO.File.Delete(resimYolu2);//Buyoldaki dosyayı sil
                }
                //Resim Silindiyse Klasör içerisinden de sildireceğiz.
                _context.Slider.Remove(slider);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SliderExists(int id)
        {
          return (_context.Slider?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
