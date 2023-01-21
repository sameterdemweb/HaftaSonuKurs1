using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneProje.Entities;
using HastaneProje.Identity;

namespace HastaneProje.Controllers
{
    public class HastaneKasaGiderController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public HastaneKasaGiderController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: HastaneKasaGider
        public async Task<IActionResult> Index()
        {
              return _context.HastaneKasaGider != null ? 
                          View(await _context.HastaneKasaGider.ToListAsync()) :
                          Problem("Entity set 'AppIdentityDbContext.HastaneKasaGider'  is null.");
        }

        // GET: HastaneKasaGider/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HastaneKasaGider == null)
            {
                return NotFound();
            }

            var hastaneKasaGider = await _context.HastaneKasaGider
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastaneKasaGider == null)
            {
                return NotFound();
            }

            return View(hastaneKasaGider);
        }

        // GET: HastaneKasaGider/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HastaneKasaGider/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ucret,Tarih,Aciklama")] HastaneKasaGider hastaneKasaGider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hastaneKasaGider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hastaneKasaGider);
        }

        // GET: HastaneKasaGider/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HastaneKasaGider == null)
            {
                return NotFound();
            }

            var hastaneKasaGider = await _context.HastaneKasaGider.FindAsync(id);
            if (hastaneKasaGider == null)
            {
                return NotFound();
            }
            return View(hastaneKasaGider);
        }

        // POST: HastaneKasaGider/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ucret,Tarih,Aciklama")] HastaneKasaGider hastaneKasaGider)
        {
            if (id != hastaneKasaGider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hastaneKasaGider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastaneKasaGiderExists(hastaneKasaGider.Id))
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
            return View(hastaneKasaGider);
        }

        // GET: HastaneKasaGider/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HastaneKasaGider == null)
            {
                return NotFound();
            }

            var hastaneKasaGider = await _context.HastaneKasaGider
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastaneKasaGider == null)
            {
                return NotFound();
            }

            return View(hastaneKasaGider);
        }

        // POST: HastaneKasaGider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HastaneKasaGider == null)
            {
                return Problem("Entity set 'AppIdentityDbContext.HastaneKasaGider'  is null.");
            }
            var hastaneKasaGider = await _context.HastaneKasaGider.FindAsync(id);
            if (hastaneKasaGider != null)
            {
                _context.HastaneKasaGider.Remove(hastaneKasaGider);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastaneKasaGiderExists(int id)
        {
          return (_context.HastaneKasaGider?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
