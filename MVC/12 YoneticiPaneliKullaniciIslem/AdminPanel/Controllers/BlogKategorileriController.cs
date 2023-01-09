using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminPanel.Entities;
using AdminPanel.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AdminPanel.Controllers
{
    [Authorize(Roles = "Admin")]// Class tepesine koyarsak bunu tüm mehodlarda kullanıcı girişi ister.
    public class BlogKategorileriController : Controller
    {
        private readonly AdminPanelContext _context;

        public BlogKategorileriController(AdminPanelContext context)
        {
            _context = context;
        }

        // GET: BlogKategorileri
        public async Task<IActionResult> Index()
        {
            var adminPanelContext = _context.BlogKategorileri.Include(b => b.BlogKategori);
            return View(await adminPanelContext.ToListAsync());
        }

        // GET: BlogKategorileri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BlogKategorileri == null)
            {
                return NotFound();
            }

            var blogKategorileri = await _context.BlogKategorileri
                .Include(b => b.BlogKategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogKategorileri == null)
            {
                return NotFound();
            }

            return View(blogKategorileri);
        }

        // GET: BlogKategorileri/Create
        public IActionResult Create()
        {
            ViewData["UstKategoriId"] = new SelectList(_context.BlogKategorileri, "Id", "KategoriAdi");
            return View();
        }

        // POST: BlogKategorileri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KategoriAdi,Durum,UstKategoriId")] BlogKategorileri blogKategorileri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogKategorileri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UstKategoriId"] = new SelectList(_context.BlogKategorileri, "Id", "KategoriAdi", blogKategorileri.UstKategoriId);
            return View(blogKategorileri);
        }

        // GET: BlogKategorileri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BlogKategorileri == null)
            {
                return NotFound();
            }

            var blogKategorileri = await _context.BlogKategorileri.FindAsync(id);
            if (blogKategorileri == null)
            {
                return NotFound();
            }
            ViewData["UstKategoriId"] = new SelectList(_context.BlogKategorileri, "Id", "KategoriAdi", blogKategorileri.UstKategoriId);
            return View(blogKategorileri);
        }

        // POST: BlogKategorileri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KategoriAdi,Durum,UstKategoriId")] BlogKategorileri blogKategorileri)
        {
            if (id != blogKategorileri.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogKategorileri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogKategorileriExists(blogKategorileri.Id))
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
            ViewData["UstKategoriId"] = new SelectList(_context.BlogKategorileri, "Id", "KategoriAdi", blogKategorileri.UstKategoriId);
            return View(blogKategorileri);
        }

        // GET: BlogKategorileri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BlogKategorileri == null)
            {
                return NotFound();
            }

            var blogKategorileri = await _context.BlogKategorileri
                .Include(b => b.BlogKategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogKategorileri == null)
            {
                return NotFound();
            }

            return View(blogKategorileri);
        }

        // POST: BlogKategorileri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BlogKategorileri == null)
            {
                return Problem("Entity set 'AdminPanelContext.BlogKategorileri'  is null.");
            }
            var blogKategorileri = await _context.BlogKategorileri.FindAsync(id);
            if (blogKategorileri != null)
            {
                _context.BlogKategorileri.Remove(blogKategorileri);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogKategorileriExists(int id)
        {
          return (_context.BlogKategorileri?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
