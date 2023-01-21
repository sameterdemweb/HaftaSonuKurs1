using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneProje.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace HastaneProje.Controllers
{
    [Authorize(Roles = "Başhekim")]
    public class RollerController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public RollerController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: Roller
        public async Task<IActionResult> Index()
        {
              return _context.IdentityRole != null ? 
                          View(await _context.IdentityRole.ToListAsync()) :
                          Problem("Entity set 'AppIdentityDbContext.IdentityRole'  is null.");
        }

        // GET: Roller/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.IdentityRole == null)
            {
                return NotFound();
            }

            var appIdentityRole = await _context.IdentityRole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appIdentityRole == null)
            {
                return NotFound();
            }

            return View(appIdentityRole);
        }

        // GET: Roller/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roller/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NormalizedName,ConcurrencyStamp")] AppIdentityRole appIdentityRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appIdentityRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appIdentityRole);
        }

        // GET: Roller/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.IdentityRole == null)
            {
                return NotFound();
            }

            var appIdentityRole = await _context.IdentityRole.FindAsync(id);
            if (appIdentityRole == null)
            {
                return NotFound();
            }
            return View(appIdentityRole);
        }

        // POST: Roller/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,NormalizedName,ConcurrencyStamp")] AppIdentityRole appIdentityRole)
        {
            if (id != appIdentityRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appIdentityRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppIdentityRoleExists(appIdentityRole.Id))
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
            return View(appIdentityRole);
        }

        // GET: Roller/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.IdentityRole == null)
            {
                return NotFound();
            }

            var appIdentityRole = await _context.IdentityRole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appIdentityRole == null)
            {
                return NotFound();
            }

            return View(appIdentityRole);
        }

        // POST: Roller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.IdentityRole == null)
            {
                return Problem("Entity set 'AppIdentityDbContext.IdentityRole'  is null.");
            }
            var appIdentityRole = await _context.IdentityRole.FindAsync(id);
            if (appIdentityRole != null)
            {
                _context.IdentityRole.Remove(appIdentityRole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppIdentityRoleExists(string id)
        {
          return (_context.IdentityRole?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
