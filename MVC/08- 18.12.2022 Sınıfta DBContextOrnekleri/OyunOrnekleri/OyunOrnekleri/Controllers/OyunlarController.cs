using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OyunOrnekleri.Entities;
using OyunOrnekleri.Identity;

namespace OyunOrnekleri.Controllers
{
    public class OyunlarController : Controller
    {
        private readonly OyunDbContext _context;

        public OyunlarController(OyunDbContext context)
        {
            _context = context;
        }

        // GET: Oyunlar
        public async Task<IActionResult> Index()
        {
              return _context.Oyunlar != null ? 
                          View(await _context.Oyunlar.ToListAsync()) :
                          Problem("Entity set 'OyunDbContext.Oyunlar'  is null.");
        }

        // GET: Oyunlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Oyunlar == null)
            {
                return NotFound();
            }

            var oyun = await _context.Oyunlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oyun == null)
            {
                return NotFound();
            }

            return View(oyun);
        }

        // GET: Oyunlar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oyunlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Fiyat,Yapimci,Indirme")] Oyun oyun)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oyun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oyun);
        }

        // GET: Oyunlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Oyunlar == null)
            {
                return NotFound();
            }

            var oyun = await _context.Oyunlar.FindAsync(id);
            if (oyun == null)
            {
                return NotFound();
            }
            return View(oyun);
        }

        // POST: Oyunlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Fiyat,Yapimci,Indirme")] Oyun oyun)
        {
            if (id != oyun.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oyun);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OyunExists(oyun.Id))
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
            return View(oyun);
        }

        // GET: Oyunlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Oyunlar == null)
            {
                return NotFound();
            }

            var oyun = await _context.Oyunlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oyun == null)
            {
                return NotFound();
            }

            return View(oyun);
        }

        // POST: Oyunlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Oyunlar == null)
            {
                return Problem("Entity set 'OyunDbContext.Oyunlar'  is null.");
            }
            var oyun = await _context.Oyunlar.FindAsync(id);
            if (oyun != null)
            {
                _context.Oyunlar.Remove(oyun);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OyunExists(int id)
        {
          return (_context.Oyunlar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
