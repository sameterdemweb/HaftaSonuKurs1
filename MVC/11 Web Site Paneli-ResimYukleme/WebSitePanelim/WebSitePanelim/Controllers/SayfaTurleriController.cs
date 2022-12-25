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
    public class SayfaTurleriController : Controller
    {
        private readonly AppWebSitePanelDbContext _context;

        public SayfaTurleriController(AppWebSitePanelDbContext context)
        {
            _context = context;
        }

        // GET: SayfaTurleri
        public async Task<IActionResult> Index()
        {
              return _context.SayfaTurleri != null ? 
                          View(await _context.SayfaTurleri.ToListAsync()) :
                          Problem("Entity set 'AppWebSitePanelDbContext.SayfaTurleri'  is null.");
        }

        // GET: SayfaTurleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SayfaTurleri == null)
            {
                return NotFound();
            }

            var sayfaTuru = await _context.SayfaTurleri
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sayfaTuru == null)
            {
                return NotFound();
            }

            return View(sayfaTuru);
        }

        // GET: SayfaTurleri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SayfaTurleri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Durum")] SayfaTuru sayfaTuru)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sayfaTuru);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sayfaTuru);
        }

        // GET: SayfaTurleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SayfaTurleri == null)
            {
                return NotFound();
            }

            var sayfaTuru = await _context.SayfaTurleri.FindAsync(id);
            if (sayfaTuru == null)
            {
                return NotFound();
            }
            return View(sayfaTuru);
        }

        // POST: SayfaTurleri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Durum")] SayfaTuru sayfaTuru)
        {
            if (id != sayfaTuru.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sayfaTuru);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SayfaTuruExists(sayfaTuru.Id))
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
            return View(sayfaTuru);
        }

        // GET: SayfaTurleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SayfaTurleri == null)
            {
                return NotFound();
            }

            var sayfaTuru = await _context.SayfaTurleri
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sayfaTuru == null)
            {
                return NotFound();
            }

            return View(sayfaTuru);
        }

        // POST: SayfaTurleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SayfaTurleri == null)
            {
                return Problem("Entity set 'AppWebSitePanelDbContext.SayfaTurleri'  is null.");
            }
            var sayfaTuru = await _context.SayfaTurleri.FindAsync(id);
            if (sayfaTuru != null)
            {
                _context.SayfaTurleri.Remove(sayfaTuru);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SayfaTuruExists(int id)
        {
          return (_context.SayfaTurleri?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
