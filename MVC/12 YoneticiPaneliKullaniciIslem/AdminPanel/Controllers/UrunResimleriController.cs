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
    public class UrunResimleriController : Controller
    {
        private readonly AdminPanelContext _context;
        private readonly IWebHostEnvironment _host; //IWebHostEnvironment www root için hosting kütüphanesini entegre ettik.


        public UrunResimleriController(AdminPanelContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }

        // GET: UrunResimleri
        public async Task<IActionResult> Index(int? id)
        {

            if(id==null || id.ToString() == "" && HttpContext.Session.GetInt32("UrunId")!=null)
            {
                id = HttpContext.Session.GetInt32("UrunId");
            }
            HttpContext.Session.SetInt32("UrunId", Convert.ToInt32(id));
            var adminPanelContext = _context.UrunFotograflari.Include(u => u.Urun).Where(f=>f.UrunId==id);
            return View(await adminPanelContext.ToListAsync());
        }

        // GET: UrunResimleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UrunFotograflari == null)
            {
                return NotFound();
            }

            var urunFotograflari = await _context.UrunFotograflari
                .Include(u => u.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urunFotograflari == null)
            {
                return NotFound();
            }

            return View(urunFotograflari);
        }

        // GET: UrunResimleri/Create
        public IActionResult Create()
        {
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "Baslik", HttpContext.Session.GetInt32("UrunId"));
            return View();
        }

        // POST: UrunResimleri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UrunId,Durum,ResimDosya")] UrunFotograflari urunFotograflari)
        {
            if (ModelState.IsValid)
            {
                // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                string wwwRootPath = _host.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(urunFotograflari.ResimDosya.FileName);//Dosya Adını Aldık.
                string extension = Path.GetExtension(urunFotograflari.ResimDosya.FileName);//Yüklenen Resmin Uzantısını Aldık.
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath, "YuklenenResimler/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await urunFotograflari.ResimDosya.CopyToAsync(fileStream);
                }

                urunFotograflari.Resim = fileName;
                // wwwroot/YuklenenResimler klasörüne resim yükleme işlemi
                _context.Add(urunFotograflari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "Baslik", urunFotograflari.UrunId);
            return View(urunFotograflari);
        }

        // GET: UrunResimleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UrunFotograflari == null)
            {
                return NotFound();
            }

            var urunFotograflari = await _context.UrunFotograflari.FindAsync(id);
            if (urunFotograflari == null)
            {
                return NotFound();
            }
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "Baslik", urunFotograflari.UrunId);
            return View(urunFotograflari);
        }

        // POST: UrunResimleri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UrunId,Durum,Resim")] UrunFotograflari urunFotograflari)
        {
            if (id != urunFotograflari.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urunFotograflari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrunFotograflariExists(urunFotograflari.Id))
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
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "Baslik", urunFotograflari.UrunId);
            return View(urunFotograflari);
        }

        // GET: UrunResimleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UrunFotograflari == null)
            {
                return NotFound();
            }

            var urunFotograflari = await _context.UrunFotograflari
                .Include(u => u.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urunFotograflari == null)
            {
                return NotFound();
            }

            return View(urunFotograflari);
        }

        // POST: UrunResimleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UrunFotograflari == null)
            {
                return Problem("Entity set 'AdminPanelContext.UrunFotograflari'  is null.");
            }
            var urunFotograflari = await _context.UrunFotograflari.FindAsync(id);
            if (urunFotograflari != null)
            {
                _context.UrunFotograflari.Remove(urunFotograflari);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrunFotograflariExists(int id)
        {
          return (_context.UrunFotograflari?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
