using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcOrnekProje2.Entities;
using MvcOrnekProje2.Identity;

namespace MvcOrnekProje2.Controllers
{
    public class CalisanlarController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public CalisanlarController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: Calisanlar
        public async Task<IActionResult> Index()
        {
              return _context.Calisanlar != null ? 
                          View(await _context.Calisanlar.ToListAsync()) :
                          Problem("Entity set 'AppIdentityDbContext.Calisanlar'  is null.");
        }

        // GET: Calisanlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Calisanlar == null)
            {
                return NotFound();
            }

            var calisan = await _context.Calisanlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calisan == null)
            {
                return NotFound();
            }

            return View(calisan);
        }

        // GET: Calisanlar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Calisanlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Soyadi,Departman,Maas")] Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calisan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calisan);
        }

        // GET: Calisanlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Calisanlar == null)
            {
                return NotFound();
            }

            var calisan = await _context.Calisanlar.FindAsync(id);
            if (calisan == null)
            {
                return NotFound();
            }
            return View(calisan);
        }

        // POST: Calisanlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Soyadi,Departman,Maas")] Calisan calisan)
        {
            if (id != calisan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calisan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalisanExists(calisan.Id))
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
            return View(calisan);
        }

        // GET: Calisanlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Calisanlar == null)
            {
                return NotFound();
            }

            var calisan = await _context.Calisanlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calisan == null)
            {
                return NotFound();
            }

            return View(calisan);
        }

        // POST: Calisanlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Calisanlar == null)
            {
                return Problem("Entity set 'AppIdentityDbContext.Calisanlar'  is null.");
            }
            var calisan = await _context.Calisanlar.FindAsync(id);
            if (calisan != null)
            {
                _context.Calisanlar.Remove(calisan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalisanExists(int id)
        {
          return (_context.Calisanlar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
