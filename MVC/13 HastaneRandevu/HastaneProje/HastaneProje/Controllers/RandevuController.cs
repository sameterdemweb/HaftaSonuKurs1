using HastaneProje.Entities;
using HastaneProje.Identity;
using HastaneProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HastaneProje.Controllers
{
    public class RandevuController : Controller
    {
        public readonly AppIdentityDbContext _context;

        public RandevuController(AppIdentityDbContext context)
        {

            _context = context;
        }


        public IActionResult Index()
        {
            List<Bolumler> bolumler = _context.Bolumler.Include(b => b.Bina).ToList();
            return View(bolumler);
        }

        public async Task<IActionResult> DoktorGetir(int? id)
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

            List<AppIdentityUser> doktorlar = _context.IdentityUser.Where(d => d.BolumId == id).ToList();

            BolumveDoktorViewModel bolumveDoktorBilgisiViewModel = new BolumveDoktorViewModel
            {
                Bolumler = bolumler,
                Doktorlar = doktorlar
            };

            return View(bolumveDoktorBilgisiViewModel);
        }


      
        public IActionResult RandevuSaatleri(string id)
        {
            if (id== null)
            {
                return NotFound();
            }

            RandevuTarihSaatViewModel bilgi = new RandevuTarihSaatViewModel
            {
                DoktorId=id,
            };

            return View(bilgi);
        }


        [HttpPost]
        public IActionResult DoktorRandevuSaatleriGetir(RandevuTarihSaatViewModel bilgiler)
        {

            if (_context.RandevuSaatleri == null)
            {
                return NotFound();
            }

            List<RandevuSaatleri> saatler = _context.RandevuSaatleri.ToList();

            DoktorRandevuSaatleriViewModel doktorRandevuSaatleri = new DoktorRandevuSaatleriViewModel
            {
                Saatler = saatler,
                DoktorTarihBilgi= bilgiler,
                Context=_context
            };


            return View(doktorRandevuSaatleri);
        }
    }
}
