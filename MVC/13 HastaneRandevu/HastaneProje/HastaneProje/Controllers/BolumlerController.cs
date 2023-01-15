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
    public class BolumlerController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public BolumlerController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: Bolumler
        public async Task<IActionResult> Index()
        {
            var appIdentityDbContext = _context.Bolumler.Include(b => b.Bina);
            return View(await appIdentityDbContext.ToListAsync());
        }

        // GET: Bolumler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bolumler == null)
            {
                return NotFound();
            }

            var bolumler = await _context.Bolumler
                .Include(b => b.Bina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bolumler == null)
            {
                return NotFound();
            }

            return View(bolumler);
        }

        // GET: Bolumler/Create
        public IActionResult Create()
        {
            ViewData["BinaId"] = new SelectList(_context.Binalar, "Id", "BinaAdi");
            return View();
        }

        // POST: Bolumler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BolumAdi,BinaId")] Bolumler bolumler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bolumler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BinaId"] = new SelectList(_context.Binalar, "Id", "BinaAdi", bolumler.BinaId);
            return View(bolumler);
        }

        // GET: Bolumler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bolumler == null)
            {
                return NotFound();
            }

            var bolumler = await _context.Bolumler.FindAsync(id);
            if (bolumler == null)
            {
                return NotFound();
            }
            ViewData["BinaId"] = new SelectList(_context.Binalar, "Id", "BinaAdi", bolumler.BinaId);
            return View(bolumler);
        }

        // POST: Bolumler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BolumAdi,BinaId")] Bolumler bolumler)
        {
            if (id != bolumler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bolumler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BolumlerExists(bolumler.Id))
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
            ViewData["BinaId"] = new SelectList(_context.Binalar, "Id", "BinaAdi", bolumler.BinaId);
            return View(bolumler);
        }

        // GET: Bolumler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bolumler == null)
            {
                return NotFound();
            }

            var bolumler = await _context.Bolumler
                .Include(b => b.Bina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bolumler == null)
            {
                return NotFound();
            }

            return View(bolumler);
        }

        // POST: Bolumler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bolumler == null)
            {
                return Problem("Entity set 'AppIdentityDbContext.Bolumler'  is null.");
            }
            var bolumler = await _context.Bolumler.FindAsync(id);
            if (bolumler != null)
            {
                _context.Bolumler.Remove(bolumler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BolumlerExists(int id)
        {
          return (_context.Bolumler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
