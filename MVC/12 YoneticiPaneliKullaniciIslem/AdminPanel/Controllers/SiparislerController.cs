using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminPanel.Entities;
using AdminPanel.Identity;

namespace AdminPanel.Controllers
{
    public class SiparislerController : Controller
    {
        private readonly AdminPanelContext _context;

        public SiparislerController(AdminPanelContext context)
        {
            _context = context;
        }


        // GET: Siparisler
        public async Task<IActionResult> Index(string? durum)
        {
             var adminPanelContext = _context.Siparisler.Include(s => s.User).Include(s => s.UyeAdres).Where(si => si.SiparisDurumu == "Ödeme Yapıldı");
             return View(await adminPanelContext.ToListAsync());
        }

        public async Task<IActionResult> Kargoda(string? durum)
        {
                var adminPanelContext = _context.Siparisler.Include(s => s.User).Include(s => s.UyeAdres).Where(si => si.SiparisDurumu == "Kargoda");
                return View(await adminPanelContext.ToListAsync());
        }


        public async Task<IActionResult> Tamamlanmis(string? durum)
        {
            var adminPanelContext = _context.Siparisler.Include(s => s.User).Include(s => s.UyeAdres).Where(si => si.SiparisDurumu == "Tamamlandı");
            return View(await adminPanelContext.ToListAsync());
        }



        public async Task<IActionResult> IptalEdilen(string? durum)
        {
            var adminPanelContext = _context.Siparisler.Include(s => s.User).Include(s => s.UyeAdres).Where(si => si.SiparisDurumu == "İptal");
            return View(await adminPanelContext.ToListAsync());
        }



        // GET: Siparisler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Siparisler == null)
            {
                return NotFound();
            }

            var siparisler = await _context.Siparisler
                .Include(s => s.User)
                .Include(s => s.UyeAdres)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siparisler == null)
            {
                return NotFound();
            }

            return View(siparisler);
        }

        // GET: Siparisler/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.AppIdentityUser, "Id", "Id");
            ViewData["AdresId"] = new SelectList(_context.UyeAdresleri, "Id", "Id");
            return View();
        }

        // POST: Siparisler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,SiparisTarihi,SiparisTutari,SiparisDurumu,AdresId,AdresBaslik,Address,PostaKodu,Telefon")] Siparisler siparisler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siparisler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.AppIdentityUser, "Id", "Id", siparisler.UserId);
            ViewData["AdresId"] = new SelectList(_context.UyeAdresleri, "Id", "Id", siparisler.AdresId);
            return View(siparisler);
        }








        // GET: Siparisler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Siparisler == null)
            {
                return NotFound();
            }

            Siparisler siparisBilgi = _context.Siparisler.Include(s => s.User).FirstOrDefault(s => s.Id == id);

            List<SiparisDetay> siparisDetay = _context.SiparisDetay.Include(s => s.Urun).Where(s => s.Id == id).ToList();

            SiparisDetayViewModel siparisDetayViewModel = new SiparisDetayViewModel
            {
                SiparisBilgi = siparisBilgi,
                SiparisDetay = siparisDetay
            };


            if (siparisBilgi == null)
            {
                return NotFound();
            }



            return View(siparisDetayViewModel);
        }












        // POST: Siparisler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SiparisDetayViewModel siparisler)
        {


            if (id == null || _context.Siparisler == null)
            {
                return NotFound();
            }

            Siparisler SiparisBilgi = await _context.Siparisler
                .Include(s => s.User)
                .Include(s => s.UyeAdres)
                .FirstOrDefaultAsync(m => m.Id == id);


            SiparisBilgi.SiparisDurumu = siparisler.SiparisBilgi.SiparisDurumu;

            try
            {
                _context.Update(SiparisBilgi);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiparislerExists(siparisler.SiparisBilgi.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            ViewData["UserId"] = new SelectList(_context.AppIdentityUser, "Id", "Id", siparisler.SiparisBilgi.UserId);
            ViewData["AdresId"] = new SelectList(_context.UyeAdresleri, "Id", "Id", siparisler.SiparisBilgi.AdresId);
            return RedirectToAction("Edit");
        }

        // GET: Siparisler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Siparisler == null)
            {
                return NotFound();
            }

            var siparisler = await _context.Siparisler
                .Include(s => s.User)
                .Include(s => s.UyeAdres)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siparisler == null)
            {
                return NotFound();
            }

            return View(siparisler);
        }

        // POST: Siparisler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Siparisler == null)
            {
                return Problem("Entity set 'AdminPanelContext.Siparisler'  is null.");
            }
            var siparisler = await _context.Siparisler.FindAsync(id);
            if (siparisler != null)
            {
                _context.Siparisler.Remove(siparisler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiparislerExists(int id)
        {
            return _context.Siparisler.Any(e => e.Id == id);
        }
    }
}
