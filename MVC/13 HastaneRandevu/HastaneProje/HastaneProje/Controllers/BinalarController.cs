using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneProje.Entities;
using HastaneProje.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace HastaneProje.Controllers
{
    [Authorize(Roles = "Başhekim,Doktorlar,Sekreter")]
    public class BinalarController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public BinalarController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: Binalar
        public async Task<IActionResult> Index()
        {
              return _context.Binalar != null ? 
                          View(await _context.Binalar.ToListAsync()) :
                          Problem("Entity set 'AppIdentityDbContext.Binalar'  is null.");
        }

        // GET: Binalar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Binalar == null)
            {
                return NotFound();
            }

            var binalar = await _context.Binalar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (binalar == null)
            {
                return NotFound();
            }

            return View(binalar);
        }

        // GET: Binalar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Binalar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BinaAdi")] Binalar binalar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(binalar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(binalar);
        }

        // GET: Binalar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Binalar == null)
            {
                return NotFound();
            }

            var binalar = await _context.Binalar.FindAsync(id);
            if (binalar == null)
            {
                return NotFound();
            }
            return View(binalar);
        }

        // POST: Binalar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BinaAdi")] Binalar binalar)
        {
            if (id != binalar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(binalar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinalarExists(binalar.Id))
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
            return View(binalar);
        }

        // GET: Binalar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Binalar == null)
            {
                return NotFound();
            }

            var binalar = await _context.Binalar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (binalar == null)
            {
                return NotFound();
            }

            return View(binalar);
        }

        // POST: Binalar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Binalar == null)
            {
                return Problem("Entity set 'AppIdentityDbContext.Binalar'  is null.");
            }
            var binalar = await _context.Binalar.FindAsync(id);
            if (binalar != null)
            {
                _context.Binalar.Remove(binalar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinalarExists(int id)
        {
          return (_context.Binalar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
