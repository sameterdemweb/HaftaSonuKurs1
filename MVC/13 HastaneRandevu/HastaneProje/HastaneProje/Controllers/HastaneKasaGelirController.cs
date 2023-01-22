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
    public class HastaneKasaGelirController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public HastaneKasaGelirController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: HastaneKasaGelir


   
            public async Task<IActionResult> Index()
        {
              return _context.HastaneKasaGelir != null ? 
                          View(await _context.HastaneKasaGelir.ToListAsync()) :
                          Problem("Entity set 'AppIdentityDbContext.HastaneKasaGelir'  is null.");
        }

        // GET: HastaneKasaGelir/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HastaneKasaGelir == null)
            {
                return NotFound();
            }

            var hastaneKasaGelir = await _context.HastaneKasaGelir
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastaneKasaGelir == null)
            {
                return NotFound();
            }

            return View(hastaneKasaGelir);
        }

        // GET: HastaneKasaGelir/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HastaneKasaGelir/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ucret,Tarih,Aciklama")] HastaneKasaGelir hastaneKasaGelir)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hastaneKasaGelir);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hastaneKasaGelir);
        }

        // GET: HastaneKasaGelir/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HastaneKasaGelir == null)
            {
                return NotFound();
            }

            var hastaneKasaGelir = await _context.HastaneKasaGelir.FindAsync(id);
            if (hastaneKasaGelir == null)
            {
                return NotFound();
            }
            return View(hastaneKasaGelir);
        }

        // POST: HastaneKasaGelir/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ucret,Tarih,Aciklama")] HastaneKasaGelir hastaneKasaGelir)
        {
            if (id != hastaneKasaGelir.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hastaneKasaGelir);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastaneKasaGelirExists(hastaneKasaGelir.Id))
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
            return View(hastaneKasaGelir);
        }

        // GET: HastaneKasaGelir/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HastaneKasaGelir == null)
            {
                return NotFound();
            }

            var hastaneKasaGelir = await _context.HastaneKasaGelir
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastaneKasaGelir == null)
            {
                return NotFound();
            }

            return View(hastaneKasaGelir);
        }

        // POST: HastaneKasaGelir/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HastaneKasaGelir == null)
            {
                return Problem("Entity set 'AppIdentityDbContext.HastaneKasaGelir'  is null.");
            }
            var hastaneKasaGelir = await _context.HastaneKasaGelir.FindAsync(id);
            if (hastaneKasaGelir != null)
            {
                _context.HastaneKasaGelir.Remove(hastaneKasaGelir);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastaneKasaGelirExists(int id)
        {
          return (_context.HastaneKasaGelir?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
