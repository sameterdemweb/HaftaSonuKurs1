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
    public class UrunKategorileriController : Controller
    {
        private readonly AdminPanelContext _context;

        public UrunKategorileriController(AdminPanelContext context)
        {
            _context = context;
        }

        // GET: UrunKategorileri
        public async Task<IActionResult> Index()
        {
            var adminPanelContext = _context.UrunKategorileri.Include(u => u.UrunKategori);
            return View(await adminPanelContext.ToListAsync());
        }

        // GET: UrunKategorileri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UrunKategorileri == null)
            {
                return NotFound();
            }

            var urunKategorileri = await _context.UrunKategorileri
                .Include(u => u.UrunKategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urunKategorileri == null)
            {
                return NotFound();
            }

            return View(urunKategorileri);
        }

        // GET: UrunKategorileri/Create
        public IActionResult Create()
        {
            ViewData["UstKategoriId"] = new SelectList(_context.UrunKategorileri, "Id", "KategoriAdi");
            return View();
        }

        // POST: UrunKategorileri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KategoriAdi,Durum,UstKategoriId")] UrunKategorileri urunKategorileri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(urunKategorileri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UstKategoriId"] = new SelectList(_context.UrunKategorileri, "Id", "KategoriAdi", urunKategorileri.UstKategoriId);
            return View(urunKategorileri);
        }

        // GET: UrunKategorileri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UrunKategorileri == null)
            {
                return NotFound();
            }

            var urunKategorileri = await _context.UrunKategorileri.FindAsync(id);
            if (urunKategorileri == null)
            {
                return NotFound();
            }
            ViewData["UstKategoriId"] = new SelectList(_context.UrunKategorileri, "Id", "KategoriAdi", urunKategorileri.UstKategoriId);
            return View(urunKategorileri);
        }

        // POST: UrunKategorileri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KategoriAdi,Durum,UstKategoriId")] UrunKategorileri urunKategorileri)
        {
            if (id != urunKategorileri.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urunKategorileri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrunKategorileriExists(urunKategorileri.Id))
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
            ViewData["UstKategoriId"] = new SelectList(_context.UrunKategorileri, "Id", "KategoriAdi", urunKategorileri.UstKategoriId);
            return View(urunKategorileri);
        }

        // GET: UrunKategorileri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UrunKategorileri == null)
            {
                return NotFound();
            }

            var urunKategorileri = await _context.UrunKategorileri
                .Include(u => u.UrunKategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urunKategorileri == null)
            {
                return NotFound();
            }

            return View(urunKategorileri);
        }

        // POST: UrunKategorileri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UrunKategorileri == null)
            {
                return Problem("Entity set 'AdminPanelContext.UrunKategorileri'  is null.");
            }
            var urunKategorileri = await _context.UrunKategorileri.FindAsync(id);
            if (urunKategorileri != null)
            {
                _context.UrunKategorileri.Remove(urunKategorileri);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrunKategorileriExists(int id)
        {
          return (_context.UrunKategorileri?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
