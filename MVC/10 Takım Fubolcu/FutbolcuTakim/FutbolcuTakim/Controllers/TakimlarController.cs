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
    public class TakimlarController : Controller
    {
        private readonly AppUygulamaDbContext _context;

        public TakimlarController(AppUygulamaDbContext context)
        {
            _context = context;
        }

        // GET: Takimlar
        public async Task<IActionResult> Index()
        {
              return _context.Takimlar != null ? 
                          View(await _context.Takimlar.ToListAsync()) :
                          Problem("Entity set 'AppUygulamaDbContext.Takimlar'  is null.");
        }

        // GET: Takimlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Takimlar == null)
            {
                return NotFound();
            }

            var takim = await _context.Takimlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (takim == null)
            {
                return NotFound();
            }

            return View(takim);
        }

        // GET: Takimlar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Takimlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Deger,Lig,Ulke")] Takim takim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(takim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(takim);
        }

        // GET: Takimlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Takimlar == null)
            {
                return NotFound();
            }

            var takim = await _context.Takimlar.FindAsync(id);
            if (takim == null)
            {
                return NotFound();
            }
            return View(takim);
        }

        // POST: Takimlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Deger,Lig,Ulke")] Takim takim)
        {
            if (id != takim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(takim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TakimExists(takim.Id))
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
            return View(takim);
        }

        // GET: Takimlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Takimlar == null)
            {
                return NotFound();
            }

            var takim = await _context.Takimlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (takim == null)
            {
                return NotFound();
            }

            return View(takim);
        }

        // POST: Takimlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Takimlar == null)
            {
                return Problem("Entity set 'AppUygulamaDbContext.Takimlar'  is null.");
            }
            var takim = await _context.Takimlar.FindAsync(id);
            if (takim != null)
            {
                _context.Takimlar.Remove(takim);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TakimExists(int id)
        {
          return (_context.Takimlar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
