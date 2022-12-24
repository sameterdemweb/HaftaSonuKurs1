using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcOrnekProje2.Entities;
using MvcOrnekProje2.Identity;
using MvcOrnekProje2.Services;

namespace MvcOrnekProje2.Controllers
{
    public class UrunlerController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public UrunlerController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: Urunler
        public async Task<IActionResult> Index()
        {
              return _context.Urunler != null ? 
                          View(await _context.Urunler.ToListAsync()) :
                          Problem("Entity set 'AppIdentityDbContext.Urunler'  is null.");
        }

        // GET: Urunler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Urunler == null)
            {
                return NotFound();
            }

            var urun = await _context.Urunler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        // GET: Urunler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Urunler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UrunAdi,BirimFiyat,UrunAdet,KdvOran")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                urun.KdvliFiyat = AletCantasi.KdvliFiyatHesapla(urun.BirimFiyat, urun.KdvOran);
                urun.ToplamFiyat = AletCantasi.FiyatHesapla(urun.UrunAdet, urun.KdvliFiyat);

                _context.Add(urun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(urun);
        }

        // GET: Urunler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Urunler == null)
            {
                return NotFound();
            }

            var urun = await _context.Urunler.FindAsync(id);
            if (urun == null)
            {
                return NotFound();
            }
            return View(urun);
        }

        // POST: Urunler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UrunAdi,BirimFiyat,UrunAdet,KdvOran")] Urun urun)
        {
            if (id != urun.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                urun.KdvliFiyat = AletCantasi.KdvliFiyatHesapla(urun.BirimFiyat, urun.KdvOran);
                urun.ToplamFiyat = AletCantasi.FiyatHesapla(urun.UrunAdet, urun.KdvliFiyat);
                try
                {
                    _context.Update(urun);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrunExists(urun.Id))
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
            return View(urun);
        }

        // GET: Urunler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Urunler == null)
            {
                return NotFound();
            }

            var urun = await _context.Urunler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        // POST: Urunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Urunler == null)
            {
                return Problem("Entity set 'AppIdentityDbContext.Urunler'  is null.");
            }
            var urun = await _context.Urunler.FindAsync(id);
            if (urun != null)
            {
                _context.Urunler.Remove(urun);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrunExists(int id)
        {
          return (_context.Urunler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
