using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneProje.Entities;
using HastaneProje.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace HastaneProje.Controllers
{
    public class RandevularController : Controller
    {
        private readonly AppIdentityDbContext _context;
        UserManager<AppIdentityUser> _userManager;
        public RandevularController(AppIdentityDbContext context, UserManager<AppIdentityUser> userManager)
        {

            _userManager = userManager;
            _context = context;
        }

        [Authorize(Roles = "Başhekim,Doktorlar,Sekreter")]// Class tepesine koyarsak bunu tüm mehodlarda kullanıcı girişi ister.
        // GET: Randevular
        public async Task<IActionResult> Index()
        {
            var appIdentityDbContext = _context.Randevular.Include(r => r.IdentityUserDoktor).Include(r => r.IdentityUserHasta).Include(r => r.RandevuSaati);
            return View(await appIdentityDbContext.ToListAsync());
        }

        [Authorize(Roles = "Başhekim,Doktorlar,Sekreter")]// Class tepesine koyarsak bunu tüm mehodlarda kullanıcı girişi ister.
        // GET: Randevular/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevular = await _context.Randevular
                .Include(r => r.IdentityUserDoktor)
                .Include(r => r.IdentityUserHasta)
                .Include(r => r.RandevuSaati)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevular == null)
            {
                return NotFound();
            }

            return View(randevular);
        }

        [Authorize(Roles = "Başhekim,Doktorlar,Sekreter")]// Class tepesine koyarsak bunu tüm mehodlarda kullanıcı girişi ister.
        // GET: Randevular/Create
        public IActionResult Create(int? SaatId, string? DoktorId, string? Tarih)
        {
            if (Tarih != null)
            {
                ViewData["Tarih"] = Tarih;
            }
            if (SaatId != null)
            {
                ViewData["SaatId"] = new SelectList(_context.RandevuSaatleri, "Id", "RandevuSaati", SaatId);
            }
            else
            {
                ViewData["SaatId"] = new SelectList(_context.RandevuSaatleri, "Id", "RandevuSaati");
            }

            if (DoktorId != null)
            {
                ViewData["DoktorId"] = new SelectList(_context.IdentityUser, "Id", "AdSoyad", DoktorId);
            }
            else
            {
                ViewData["DoktorId"] = new SelectList(_context.IdentityUser, "Id", "AdSoyad");
            }
           
            ViewData["HastaId"] = new SelectList(_context.IdentityUser, "Id", "AdSoyad");
            

            return View();
        }

        // POST: Randevular/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HastaId,DoktorId,SaatId,Ucret,Aciklama,Tarih")] Randevular randevular)
        {
            if (ModelState.IsValid)
            {
                Randevular randevuBilgisi = await _context.Randevular
               .Include(r => r.IdentityUserDoktor)
               .Include(r => r.IdentityUserHasta)
               .Include(r => r.RandevuSaati)
               .FirstOrDefaultAsync(m => m.DoktorId == randevular.DoktorId && m.Tarih==randevular.Tarih && m.SaatId== randevular.SaatId);

                if (randevuBilgisi!=null)
                {
                    //return Problem("Bu doktora ait seçilen saatte randevu bulunmaktadır. Lütfen başka bir tarih seçimi yapın.");
                    // Bu kullanıcıya ait randevu bilgisi mevcut
                    ViewData["Hata"] = "Bu doktora ait seçilen saatte randevu bulunmaktadır. Lütfen başka bir tarih seçimi yapın.";
                }
                else
                {
                    
                    _context.Randevular.Add(randevular);
                    await _context.SaveChangesAsync();

                    HastaneKasaGelir RandevudanGelenGelir = new HastaneKasaGelir
                    {
                        Ucret = randevular.Ucret,
                        Tarih = randevular.Tarih,
                        Aciklama = randevular.HastaId + " ID'li hastanın, " + randevular.Tarih + " tarihli randevusundan kayıt alındı."
                    };
                    _context.HastaneKasaGelir.Add(RandevudanGelenGelir);
                    await _context.SaveChangesAsync();



                    return RedirectToAction("RandevuOlusturulduYetkili");
                }
            }
            ViewData["DoktorId"] = new SelectList(_context.IdentityUser, "Id", "AdSoyad", randevular.DoktorId);
            ViewData["HastaId"] = new SelectList(_context.IdentityUser, "Id", "AdSoyad", randevular.HastaId);
            ViewData["SaatId"] = new SelectList(_context.RandevuSaatleri, "Id", "RandevuSaati", randevular.SaatId);
            return View(randevular);
        }
        [Authorize]// Class tepesine koyarsak bunu tüm mehodlarda kullanıcı girişi ister.

        // [Authorize(Roles = "Hasta")]// Class tepesine koyarsak bunu tüm mehodlarda kullanıcı girişi ister.
        public IActionResult CreateHastaRandevu()
        {
            ViewData["DoktorId"] = new SelectList(_context.IdentityUser, "Id", "AdSoyad");
            ViewData["SaatId"] = new SelectList(_context.RandevuSaatleri, "Id", "RandevuSaati");
            return View();
        }



        public IActionResult RandevuOlusturuldu()
        {
            return View();
        }

        public IActionResult RandevuOlusturulduYetkili()
        {
            return View();
        }
        // POST: Randevular/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //  [Authorize(Roles = "Hasta")]// Class tepesine koyarsak bunu tüm mehodlarda kullanıcı girişi ister.
        [HttpPost]
        [Authorize]// Class tepesine koyarsak bunu tüm mehodlarda kullanıcı girişi ister.
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHastaRandevu([Bind("Id,DoktorId,SaatId,Ucret,Aciklama,Tarih")] Randevular randevular)
        {
            var girisYapanKullanici = await _userManager.GetUserAsync(User);//Sisteme Giriş Yapan kullanıcı Bilgilerini aldık.

            randevular.HastaId = girisYapanKullanici.Id;

            if (!ModelState.IsValid)
            {

                var randevuBilgisi = await _context.Randevular
               .Include(r => r.IdentityUserDoktor)
               .Include(r => r.IdentityUserHasta)
               .Include(r => r.RandevuSaati)
               .FirstOrDefaultAsync(m => m.DoktorId == randevular.DoktorId && m.Tarih == randevular.Tarih && m.SaatId == randevular.SaatId);

                if (randevuBilgisi != null)
                {
                    //return Problem("Bu doktora ait seçilen saatte randevu bulunmaktadır. Lütfen başka bir tarih seçimi yapın.");

                    // Bu kullanıcıya ait randevu bilgisi mevcut
                     ViewData["Hata"]= "Bu doktora ait seçilen saatte randevu bulunmaktadır. Lütfen başka bir tarih seçimi yapın.";
                }
                else
                {

                    _context.Add(randevular);
                    await _context.SaveChangesAsync();

                    HastaneKasaGelir RandevudanGelenGelir = new HastaneKasaGelir
                    {
                        Ucret = randevular.Ucret,
                        Tarih = randevular.Tarih,
                        Aciklama = randevular.HastaId + " ID'li hastanın, " + randevular.Tarih + " tarihli randevusundan kayıt alındı."
                    };
                    _context.HastaneKasaGelir.Add(RandevudanGelenGelir);
                    await _context.SaveChangesAsync();


                    return RedirectToAction("RandevuOlusturuldu");
                }
            }
            ViewData["DoktorId"] = new SelectList(_context.IdentityUser, "Id", "AdSoyad", randevular.DoktorId);
          
            ViewData["SaatId"] = new SelectList(_context.RandevuSaatleri, "Id", "RandevuSaati", randevular.SaatId);
            return View(randevular);
        }


        // GET: Randevular/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevular = await _context.Randevular.FindAsync(id);
            if (randevular == null)
            {
                return NotFound();
            }
            ViewData["DoktorId"] = new SelectList(_context.IdentityUser, "Id", "AdSoyad", randevular.DoktorId);
            ViewData["HastaId"] = new SelectList(_context.IdentityUser, "Id", "AdSoyad", randevular.HastaId);
            ViewData["SaatId"] = new SelectList(_context.RandevuSaatleri, "Id", "RandevuSaati", randevular.SaatId);
            return View(randevular);
        }

        // POST: Randevular/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HastaId,DoktorId,SaatId,Ucret,Aciklama,Tarih")] Randevular randevular)
        {
            if (id != randevular.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevularExists(randevular.Id))
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
            ViewData["DoktorId"] = new SelectList(_context.IdentityUser, "Id", "AdSoyad", randevular.DoktorId);
            ViewData["HastaId"] = new SelectList(_context.IdentityUser, "Id", "AdSoyad", randevular.HastaId);
            ViewData["SaatId"] = new SelectList(_context.RandevuSaatleri, "Id", "RandevuSaati", randevular.SaatId);
            return View(randevular);
        }

        // GET: Randevular/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Randevular == null)
            {
                return NotFound();
            }

            var randevular = await _context.Randevular
                .Include(r => r.IdentityUserDoktor)
                .Include(r => r.IdentityUserHasta)
                .Include(r => r.RandevuSaati)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevular == null)
            {
                return NotFound();
            }

            return View(randevular);
        }

        // POST: Randevular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Randevular == null)
            {
                return Problem("Entity set 'AppIdentityDbContext.Randevular'  is null.");
            }
            var randevular = await _context.Randevular.FindAsync(id);
            if (randevular != null)
            {
                _context.Randevular.Remove(randevular);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevularExists(int id)
        {
          return (_context.Randevular?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
