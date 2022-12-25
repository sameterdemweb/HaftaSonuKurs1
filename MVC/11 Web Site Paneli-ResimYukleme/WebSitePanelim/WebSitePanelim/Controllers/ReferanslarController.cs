using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSitePanelim.Entities;
using WebSitePanelim.Identity;

namespace WebSitePanelim.Controllers
{
    public class ReferanslarController : Controller
    {
        private readonly AppWebSitePanelDbContext _context;

        public ReferanslarController(AppWebSitePanelDbContext context)
        {
            _context = context;
        }

        // GET: Referanslar
        public async Task<IActionResult> Index()
        {
              return _context.Referanslar != null ? 
                          View(await _context.Referanslar.ToListAsync()) :
                          Problem("Entity set 'AppWebSitePanelDbContext.Referanslar'  is null.");
        }

        // GET: Referanslar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Referanslar == null)
            {
                return NotFound();
            }

            var referans = await _context.Referanslar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referans == null)
            {
                return NotFound();
            }

            return View(referans);
        }

        // GET: Referanslar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Referanslar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tarih,Url,Baslik,KisaBaslik,Aciklama,Resim")] Referans referans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(referans);
        }

        // GET: Referanslar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Referanslar == null)
            {
                return NotFound();
            }

            var referans = await _context.Referanslar.FindAsync(id);
            if (referans == null)
            {
                return NotFound();
            }
            return View(referans);
        }

        // POST: Referanslar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tarih,Url,Baslik,KisaBaslik,Aciklama,Resim")] Referans referans)
        {
            if (id != referans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferansExists(referans.Id))
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
            return View(referans);
        }

        // GET: Referanslar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Referanslar == null)
            {
                return NotFound();
            }

            var referans = await _context.Referanslar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referans == null)
            {
                return NotFound();
            }

            return View(referans);
        }

        // POST: Referanslar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Referanslar == null)
            {
                return Problem("Entity set 'AppWebSitePanelDbContext.Referanslar'  is null.");
            }
            var referans = await _context.Referanslar.FindAsync(id);
            if (referans != null)
            {
                _context.Referanslar.Remove(referans);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferansExists(int id)
        {
          return (_context.Referanslar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
