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
        private readonly AppWebSitePanelDbContext _context;

        public IceriklerController(AppWebSitePanelDbContext context)
        {
            _context = context;
        }

        // GET: Icerikler
        public async Task<IActionResult> Index(int? TurId)
        {
            if (TurId == null)
            {
                var appWebSitePanelDbContext = _context.Icerikler.Include(i => i.SayfaTuru);
                return View(await appWebSitePanelDbContext.ToListAsync());
            }
            else { 
                var appWebSitePanelDbContext = _context.Icerikler.Include(i => i.SayfaTuru).Where(g=>g.TurId== TurId);
                return View(await appWebSitePanelDbContext.ToListAsync());
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
            ViewData["TurId"] = new SelectList(_context.SayfaTurleri, "Id", "Adi");
            return View();
        }

        // POST: Icerikler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TurId,Baslik,KisaAciklama,Aciklama,Resim,Tarih")] Icerik icerik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(icerik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TurId"] = new SelectList(_context.SayfaTurleri, "Id", "Adi", icerik.TurId);
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
            ViewData["TurId"] = new SelectList(_context.SayfaTurleri, "Id", "Adi", icerik.TurId);
            return View(icerik);
        }

        // POST: Icerikler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TurId,Baslik,KisaAciklama,Aciklama,Resim,Tarih")] Icerik icerik)
        {
            if (id != icerik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            ViewData["TurId"] = new SelectList(_context.SayfaTurleri, "Id", "Adi", icerik.TurId);
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
                return Problem("Entity set 'AppWebSitePanelDbContext.Icerikler'  is null.");
            }
            var icerik = await _context.Icerikler.FindAsync(id);
            if (icerik != null)
            {
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
