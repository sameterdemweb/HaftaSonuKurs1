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
    public class UrunlerController : Controller
    {
        private readonly AdminPanelContext _context;
        private readonly IWebHostEnvironment _host; //IWebHostEnvironment www root için hosting kütüphanesini entegre ettik.

        public UrunlerController(AdminPanelContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }

        // GET: Urunler
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var adminPanelContext = _context.Urunler.Include(u => u.UrunKategori);
            return View(await adminPanelContext.ToListAsync());
        }

        // GET: Urunler/Details/5
        [Authorize(Roles = "Uye,Admin,Editör")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Urunler == null)
            {
                return NotFound();
            }

            var urunler = await _context.Urunler
                .Include(u => u.UrunKategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urunler == null)
            {
                return NotFound();
            }

            return View(urunler);
        }


        // GET: Urunler/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.UrunKategorileri, "Id", "KategoriAdi");
            return View();
        }

        // POST: Urunler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,KategoriId,Durum,Baslik,StandartAciklama, StandartFiyat,TopNote,MiddleNote,BaseNote,ResimDosya,KisaAciklama,Icerik")] Urunler urunler)
        {
            if (ModelState.IsValid)
            {
                if (urunler.ResimDosya != null)
                {

                    // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                    string wwwRootPath = _host.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(urunler.ResimDosya.FileName);//Dosya Adını Aldık.
                    string extension = Path.GetExtension(urunler.ResimDosya.FileName);//Yüklenen Resmin Uzantısını Aldık.
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath, "YuklenenResimler/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await urunler.ResimDosya.CopyToAsync(fileStream);
                    }

                    urunler.Resim = fileName;
                }
                // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi

                _context.Add(urunler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.UrunKategorileri, "Id", "KategoriAdi", urunler.KategoriId);
            return View(urunler);
        }

        // GET: Urunler/Edit/5
        [Authorize(Roles = "Admin,Editör")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Urunler == null)
            {
                return NotFound();
            }

            var urunler = await _context.Urunler.FindAsync(id);
            if (urunler == null)
            {
                return NotFound();
            }
            if (urunler.Resim != null)
            {
                HttpContext.Session.SetString("Resim", urunler.Resim);
            }
    
            ViewData["KategoriId"] = new SelectList(_context.UrunKategorileri, "Id", "KategoriAdi", urunler.KategoriId);
            return View(urunler);
        }

        // POST: Urunler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Editör")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KategoriId,Durum,Baslik,StandartAciklama, StandartFiyat,TopNote,MiddleNote,BaseNote,ResimDosya,KisaAciklama,Icerik")] Urunler urunler)
        {
            if (id != urunler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (urunler.ResimDosya != null)
                    {

                  
                        // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                        string wwwRootPath = _host.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(urunler.ResimDosya.FileName);//Dosya Adını Aldık.
                        string extension = Path.GetExtension(urunler.ResimDosya.FileName);//Yüklenen Resmin Uzantısını Aldık.
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath, "YuklenenResimler/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await urunler.ResimDosya.CopyToAsync(fileStream);
                        }

                        urunler.Resim = fileName;
                        // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                    }
                    else if (HttpContext.Session.GetString("Resim") != null)
                    {
                        urunler.Resim = HttpContext.Session.GetString("Resim");
                    }
                    _context.Update(urunler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrunlerExists(urunler.Id))
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
            ViewData["KategoriId"] = new SelectList(_context.UrunKategorileri, "Id", "KategoriAdi", urunler.KategoriId);
            return View(urunler);
        }

        // GET: Urunler/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Urunler == null)
            {
                return NotFound();
            }

            var urunler = await _context.Urunler
                .Include(u => u.UrunKategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urunler == null)
            {
                return NotFound();
            }

            return View(urunler);
        }

        // POST: Urunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Urunler == null)
            {
                return Problem("Entity set 'AdminPanelContext.Urunler'  is null.");
            }
            var urun = await _context.Urunler.FindAsync(id);
            if (urun != null)
            {
                //Resim Silindiyse Klasör içerisinden de sildireceğiz. Kök dizin klasöründen de silinecek.
                var resimYolu = Path.Combine(_host.WebRootPath, "YuklenenResimler", urun.Resim);
                if (System.IO.File.Exists(resimYolu))//Bu belirlenen yolda bir dosya var mı?
                {
                    System.IO.File.Delete(resimYolu);//Buyoldaki dosyayı sil
                }
                //Resim Silindiyse Klasör içerisinden de sildireceğiz.
                _context.Urunler.Remove(urun);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrunlerExists(int id)
        {
          return (_context.Urunler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
