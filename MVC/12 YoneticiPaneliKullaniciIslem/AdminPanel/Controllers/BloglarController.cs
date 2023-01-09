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
    public class BloglarController : Controller
    {
        private readonly AdminPanelContext _context;
        private readonly IWebHostEnvironment _host; //IWebHostEnvironment www root için hosting kütüphanesini entegre ettik.

        public BloglarController(AdminPanelContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }

        // GET: Bloglar
        public async Task<IActionResult> Index()
        {
            var adminPanelContext = _context.Bloglar.Include(b => b.BlogKategori);
            return View(await adminPanelContext.ToListAsync());
        }

        // GET: Bloglar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bloglar == null)
            {
                return NotFound();
            }

            var bloglar = await _context.Bloglar
                .Include(b => b.BlogKategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloglar == null)
            {
                return NotFound();
            }

            return View(bloglar);
        }

        // GET: Bloglar/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.BlogKategorileri, "Id", "KategoriAdi");
            return View();
        }

        // POST: Bloglar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KategoriId,Durum,Baslik,ResimDosya,KisaAciklama,Icerik")] Bloglar bloglar)
        {
            if (ModelState.IsValid)
            {
                if (bloglar.ResimDosya != null)
                {
                    // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                    string wwwRootPath = _host.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(bloglar.ResimDosya.FileName);//Dosya Adını Aldık.
                    string extension = Path.GetExtension(bloglar.ResimDosya.FileName);//Yüklenen Resmin Uzantısını Aldık.
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath, "YuklenenResimler/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await bloglar.ResimDosya.CopyToAsync(fileStream);
                    }

                    bloglar.Resim = fileName;
                    // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                }

                _context.Add(bloglar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.BlogKategorileri, "Id", "KategoriAdi", bloglar.KategoriId);
            return View(bloglar);
        }

        // GET: Bloglar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bloglar == null)
            {
                return NotFound();
            }

            var bloglar = await _context.Bloglar.FindAsync(id);
            if (bloglar == null)
            {
                return NotFound();
            }
            if (bloglar.Resim != null)
            {
                HttpContext.Session.SetString("Resim", bloglar.Resim);
            }
            ViewData["KategoriId"] = new SelectList(_context.BlogKategorileri, "Id", "KategoriAdi", bloglar.KategoriId);
            return View(bloglar);
        }

        // POST: Bloglar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KategoriId,Durum,Baslik,ResimDosya,KisaAciklama,Icerik")] Bloglar bloglar)
        {
            if (id != bloglar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (bloglar.ResimDosya != null)
                    {

                        // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                        string wwwRootPath = _host.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(bloglar.ResimDosya.FileName);//Dosya Adını Aldık.
                        string extension = Path.GetExtension(bloglar.ResimDosya.FileName);//Yüklenen Resmin Uzantısını Aldık.
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath, "YuklenenResimler/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await bloglar.ResimDosya.CopyToAsync(fileStream);
                        }

                        bloglar.Resim = fileName;
                        // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                    }
                    else if(HttpContext.Session.GetString("Resim")!=null)
                    {
                        bloglar.Resim = HttpContext.Session.GetString("Resim");
                    }

                    _context.Update(bloglar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloglarExists(bloglar.Id))
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
            ViewData["KategoriId"] = new SelectList(_context.BlogKategorileri, "Id", "KategoriAdi", bloglar.KategoriId);
            return View(bloglar);
        }

        // GET: Bloglar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bloglar == null)
            {
                return NotFound();
            }

            var bloglar = await _context.Bloglar
                .Include(b => b.BlogKategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloglar == null)
            {
                return NotFound();
            }

            return View(bloglar);
        }

        // POST: Bloglar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bloglar == null)
            {
                return Problem("Entity set 'AdminPanelContext.Bloglar'  is null.");
            }
            var bloglar = await _context.Bloglar.FindAsync(id);
            if (bloglar != null)
            {

                //Resim Silindiyse Klasör içerisinden de sildireceğiz. Kök dizin klasöründen de silinecek.
                var resimYolu = Path.Combine(_host.WebRootPath, "YuklenenResimler", bloglar.Resim);
                if (System.IO.File.Exists(resimYolu))//Bu belirlenen yolda bir dosya var mı?
                {
                    System.IO.File.Delete(resimYolu);//Buyoldaki dosyayı sil
                }
                //Resim Silindiyse Klasör içerisinden de sildireceğiz.

                _context.Bloglar.Remove(bloglar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloglarExists(int id)
        {
          return (_context.Bloglar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
