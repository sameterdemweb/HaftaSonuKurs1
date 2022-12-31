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
    public class SayfaTurulerController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public SayfaTurulerController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: SayfaTuruler
        public async Task<IActionResult> Index()
        {
              return _context.SayfaTuruler != null ? 
                          View(await _context.SayfaTuruler.ToListAsync()) :
                          Problem("Entity set 'AppIdentityDbContext.SayfaTuruler'  is null.");
        }

        // GET: SayfaTuruler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SayfaTuruler == null)
            {
                return NotFound();
            }

            var sayfaTuru = await _context.SayfaTuruler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sayfaTuru == null)
            {
                return NotFound();
            }

            return View(sayfaTuru);
        }

        // GET: SayfaTuruler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SayfaTuruler/Create
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

        // GET: SayfaTuruler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SayfaTuruler == null)
            {
                return NotFound();
            }

            var sayfaTuru = await _context.SayfaTuruler.FindAsync(id);
            if (sayfaTuru == null)
            {
                return NotFound();
            }
            return View(sayfaTuru);
        }

        // POST: SayfaTuruler/Edit/5
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

        // GET: SayfaTuruler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SayfaTuruler == null)
            {
                return NotFound();
            }

            var sayfaTuru = await _context.SayfaTuruler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sayfaTuru == null)
            {
                return NotFound();
            }

            return View(sayfaTuru);
        }

        // POST: SayfaTuruler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SayfaTuruler == null)
            {
                return Problem("Entity set 'AppIdentityDbContext.SayfaTuruler'  is null.");
            }
            var sayfaTuru = await _context.SayfaTuruler.FindAsync(id);
            if (sayfaTuru != null)
            {
                _context.SayfaTuruler.Remove(sayfaTuru);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SayfaTuruExists(int id)
        {
          return (_context.SayfaTuruler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
