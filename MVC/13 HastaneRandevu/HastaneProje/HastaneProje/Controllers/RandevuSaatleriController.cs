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
    [Authorize(Roles = "Başhekim")]
    public class RandevuSaatleriController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public RandevuSaatleriController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: RandevuSaatleri
        public async Task<IActionResult> Index()
        {
              return _context.RandevuSaatleri != null ? 
                          View(await _context.RandevuSaatleri.ToListAsync()) :
                          Problem("Entity set 'AppIdentityDbContext.RandevuSaatleri'  is null.");
        }

        // GET: RandevuSaatleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RandevuSaatleri == null)
            {
                return NotFound();
            }

            var randevuSaatleri = await _context.RandevuSaatleri
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevuSaatleri == null)
            {
                return NotFound();
            }

            return View(randevuSaatleri);
        }

        // GET: RandevuSaatleri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RandevuSaatleri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RandevuSaati")] RandevuSaatleri randevuSaatleri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(randevuSaatleri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(randevuSaatleri);
        }

        // GET: RandevuSaatleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RandevuSaatleri == null)
            {
                return NotFound();
            }

            var randevuSaatleri = await _context.RandevuSaatleri.FindAsync(id);
            if (randevuSaatleri == null)
            {
                return NotFound();
            }
            return View(randevuSaatleri);
        }

        // POST: RandevuSaatleri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RandevuSaati")] RandevuSaatleri randevuSaatleri)
        {
            if (id != randevuSaatleri.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevuSaatleri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevuSaatleriExists(randevuSaatleri.Id))
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
            return View(randevuSaatleri);
        }

        // GET: RandevuSaatleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RandevuSaatleri == null)
            {
                return NotFound();
            }

            var randevuSaatleri = await _context.RandevuSaatleri
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevuSaatleri == null)
            {
                return NotFound();
            }

            return View(randevuSaatleri);
        }

        // POST: RandevuSaatleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RandevuSaatleri == null)
            {
                return Problem("Entity set 'AppIdentityDbContext.RandevuSaatleri'  is null.");
            }
            var randevuSaatleri = await _context.RandevuSaatleri.FindAsync(id);
            if (randevuSaatleri != null)
            {
                _context.RandevuSaatleri.Remove(randevuSaatleri);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuSaatleriExists(int id)
        {
          return (_context.RandevuSaatleri?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
