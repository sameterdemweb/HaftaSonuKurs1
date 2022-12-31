using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSitePanelim.Entities;
using WebSitePanelim.Identity;

namespace WebSitePanelim.Controllers
{
    public class IceriklerController : Controller
    {
        private readonly AppIdentityDbContext _context;
        private readonly IWebHostEnvironment _host;

        public IceriklerController(AppIdentityDbContext context, IWebHostEnvironment host)
        {

            _context = context;
            _host = host;   
        }

        // GET: Icerikler
        public async Task<IActionResult> Index(int? TurId)
        {
            if (TurId == null)
            {
                var appIdentityDbContext = _context.Icerikler.Include(i => i.SayfaTuru);
                return View(await appIdentityDbContext.ToListAsync());
            }
            else
            {
                var appIdentityDbContext = _context.Icerikler.Include(i => i.SayfaTuru).Where(g => g.TurId == TurId);
                return View(await appIdentityDbContext.ToListAsync());
            }
        }

        // GET: Icerikler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Icerikler == null)
            {
                return NotFound();
            }

            var icerik = await _context.Icerikler
                .Include(i => i.SayfaTuru)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (icerik == null)
            {
                return NotFound();
            }

            return View(icerik);
        }

        // GET: Icerikler/Create
        public IActionResult Create()
        {
            ViewData["TurId"] = new SelectList(_context.SayfaTuruler, "Id", "Adi");
            return View();
        }

        // POST: Icerikler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,KisaAciklama,Aciklama,ResimDosya,Tarih,TurId")] Icerik icerik)
        {
            if (ModelState.IsValid)
            {
                // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                string wwwRootPath = _host.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(icerik.ResimDosya.FileName);//Dosya Adını Aldık.
                string extension = Path.GetExtension(icerik.ResimDosya.FileName);//Yüklenen Resmin Uzantısını Aldık.
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath, "Upload/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await icerik.ResimDosya.CopyToAsync(fileStream);
                }

                icerik.Resim = fileName;
                // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                _context.Add(icerik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TurId"] = new SelectList(_context.SayfaTuruler, "Id", "Adi", icerik.TurId);
            return View(icerik);
        }

        // GET: Icerikler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Icerikler == null)
            {
                return NotFound();
            }

            var icerik = await _context.Icerikler.FindAsync(id);
            if (icerik == null)
            {
                return NotFound();
            }

            if (icerik.Resim != null)
            {
                HttpContext.Session.SetString("Resim", icerik.Resim);
            }


            ViewData["TurId"] = new SelectList(_context.SayfaTuruler, "Id", "Adi", icerik.TurId);
            return View(icerik);
        }

        // POST: Icerikler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,KisaAciklama,Aciklama,ResimDosya,Tarih,TurId")] Icerik icerik)
        {
            if (id != icerik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                    if (icerik.ResimDosya!=null && icerik.ResimDosya.ToString()!="") {
                        string wwwRootPath = _host.WebRootPath;

                        string fileName = Path.GetFileNameWithoutExtension(icerik.ResimDosya.FileName);//Dosya Adını Aldık.
                        string extension = Path.GetExtension(icerik.ResimDosya.FileName);//Yüklenen Resmin Uzantısını Aldık.
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath, "Upload/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await icerik.ResimDosya.CopyToAsync(fileStream);
                        }

                        icerik.Resim = fileName;

                        if (HttpContext.Session.GetString("Resim") != null)
                        {
                            //Resim Silindiyse Klasör içerisinden de sildireceğiz. Kök dizin klasöründen de silinecek.
                            var resimYolu = Path.Combine(_host.WebRootPath, "Upload", HttpContext.Session.GetString("Resim"));
                            if (System.IO.File.Exists(resimYolu))//Bu belirlenen yolda bir dosya var mı?
                            {
                                System.IO.File.Delete(resimYolu);//Buyoldaki dosyayı sil
                            }
                            //Resim Silindiyse Klasör içerisinden de sildireceğiz.
                         
                        }
                       

                    }
                    else if (HttpContext.Session.GetString("Resim") != null)
                    {
                        icerik.Resim = HttpContext.Session.GetString("Resim");
                    }


                    // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi

                    _context.Update(icerik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IcerikExists(icerik.Id))
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
            ViewData["TurId"] = new SelectList(_context.SayfaTuruler, "Id", "Adi", icerik.TurId);
            return View(icerik);

        }

        // GET: Icerikler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Icerikler == null)
            {
                return NotFound();
            }

            var icerik = await _context.Icerikler
                .Include(i => i.SayfaTuru)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (icerik == null)
            {
                return NotFound();
            }

            return View(icerik);
        }

        // POST: Icerikler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Icerikler == null)
            {
                return Problem("Entity set 'AppIdentityDbContext.Icerikler'  is null.");
            }
            var icerik = await _context.Icerikler.FindAsync(id);
            if (icerik != null)
            {

                //Resim Silindiyse Klasör içerisinden de sildireceğiz. Kök dizin klasöründen de silinecek.
                var resimYolu = Path.Combine(_host.WebRootPath, "Upload", icerik.Resim);
                if (System.IO.File.Exists(resimYolu))//Bu belirlenen yolda bir dosya var mı?
                {
                    System.IO.File.Delete(resimYolu);//Buyoldaki dosyayı sil
                }
                //Resim Silindiyse Klasör içerisinden de sildireceğiz.

                _context.Icerikler.Remove(icerik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IcerikExists(int id)
        {
          return (_context.Icerikler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
