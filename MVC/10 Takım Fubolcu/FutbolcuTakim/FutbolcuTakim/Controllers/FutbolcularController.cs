using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FutbolcuTakim.Entities;
using FutbolcuTakim.Identity;

namespace FutbolcuTakim.Controllers
{
    public class FutbolcularController : Controller
    {
        private readonly AppUygulamaDbContext _context;

        public FutbolcularController(AppUygulamaDbContext context)
        {
            _context = context;
        }

        // GET: Futbolcular
        public async Task<IActionResult> Index()
        {
            var appUygulamaDbContext = _context.Futbolcular.Include(t=> t.Takim);
            return View(await appUygulamaDbContext.ToListAsync());
        }

        // GET: Futbolcular/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Futbolcular == null)
            {
                return NotFound();
            }

            var futbolcu = await _context.Futbolcular
                .Include(f => f.Takim)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (futbolcu == null)
            {
                return NotFound();
            }

            return View(futbolcu);
        }

        // GET: Futbolcular/Create
        public IActionResult Create()
        {
            ViewData["TakimId"] = new SelectList(_context.Takimlar, "Id", "Adi");
            return View();
        }

        // POST: Futbolcular/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Soyadi,Deger,Ulke,TakimId")] Futbolcu futbolcu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(futbolcu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TakimId"] = new SelectList(_context.Takimlar, "Id", "Adi", futbolcu.TakimId);
            return View(futbolcu);
        }

        // GET: Futbolcular/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Futbolcular == null)
            {
                return NotFound();
            }

            var futbolcu = await _context.Futbolcular.FindAsync(id);
            if (futbolcu == null)
            {
                return NotFound();
            }
            ViewData["TakimId"] = new SelectList(_context.Takimlar, "Id", "Adi", futbolcu.TakimId);
            return View(futbolcu);
        }

        // POST: Futbolcular/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Soyadi,Deger,Ulke,TakimId")] Futbolcu futbolcu)
        {
            if (id != futbolcu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(futbolcu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FutbolcuExists(futbolcu.Id))
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
            ViewData["TakimId"] = new SelectList(_context.Takimlar, "Id", "Adi", futbolcu.TakimId);
            return View(futbolcu);
        }

        // GET: Futbolcular/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Futbolcular == null)
            {
                return NotFound();
            }

            var futbolcu = await _context.Futbolcular
                .Include(f => f.Takim)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (futbolcu == null)
            {
                return NotFound();
            }

            return View(futbolcu);
        }

        // POST: Futbolcular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Futbolcular == null)
            {
                return Problem("Entity set 'AppUygulamaDbContext.Futbolcular'  is null.");
            }
            var futbolcu = await _context.Futbolcular.FindAsync(id);
            if (futbolcu != null)
            {
                _context.Futbolcular.Remove(futbolcu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FutbolcuExists(int id)
        {
          return (_context.Futbolcular?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
