using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdresTutma.Entities;
using AdresTutma.Identity;

namespace AdresTutma.Controllers
{
    public class KisiBilgileriController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public KisiBilgileriController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: KisiBilgileri
        public async Task<IActionResult> Index()
        {
              return _context.KisiBilgileri != null ? 
                          View(await _context.KisiBilgileri.ToListAsync()) :
                          Problem("Entity set 'AppIdentityDbContext.KisiBilgileri'  is null.");
        }

        // GET: KisiBilgileri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KisiBilgileri == null)
            {
                return NotFound();
            }

            var kisiBilgileri = await _context.KisiBilgileri
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kisiBilgileri == null)
            {
                return NotFound();
            }

            return View(kisiBilgileri);
        }

        // GET: KisiBilgileri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KisiBilgileri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Soyadi,Adres,TelefonNo")] KisiBilgileri kisiBilgileri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kisiBilgileri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kisiBilgileri);
        }

        // GET: KisiBilgileri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KisiBilgileri == null)
            {
                return NotFound();
            }

            var kisiBilgileri = await _context.KisiBilgileri.FindAsync(id);
            if (kisiBilgileri == null)
            {
                return NotFound();
            }
            return View(kisiBilgileri);
        }

        // POST: KisiBilgileri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Soyadi,Adres,TelefonNo")] KisiBilgileri kisiBilgileri)
        {
            if (id != kisiBilgileri.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kisiBilgileri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KisiBilgileriExists(kisiBilgileri.Id))
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
            return View(kisiBilgileri);
        }

        // GET: KisiBilgileri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KisiBilgileri == null)
            {
                return NotFound();
            }

            var kisiBilgileri = await _context.KisiBilgileri
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kisiBilgileri == null)
            {
                return NotFound();
            }

            return View(kisiBilgileri);
        }

        // POST: KisiBilgileri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KisiBilgileri == null)
            {
                return Problem("Entity set 'AppIdentityDbContext.KisiBilgileri'  is null.");
            }
            var kisiBilgileri = await _context.KisiBilgileri.FindAsync(id);
            if (kisiBilgileri != null)
            {
                _context.KisiBilgileri.Remove(kisiBilgileri);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KisiBilgileriExists(int id)
        {
          return (_context.KisiBilgileri?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
