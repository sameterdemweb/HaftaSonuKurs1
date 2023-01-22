using HastaneProje.Entities;
using HastaneProje.Identity;
using Microsoft.EntityFrameworkCore;

namespace HastaneProje.Servisler
{
    public class AletCantasi
    {

        private readonly AppIdentityDbContext _context;

        public AletCantasi(AppIdentityDbContext context)
        {
            _context = context;
        }

        public string RandevuVarMi(string DoktorId, int SaatId, string Tarih)
        {

            DateTime tarihBilgi = Convert.ToDateTime(Tarih);
            int randevuBilgisi = _context.Randevular.Where(m => m.DoktorId == DoktorId && m.Tarih == tarihBilgi && m.SaatId == SaatId).Count();

            if (randevuBilgisi > 0)
            {
                return "1";
            }
            else
            {
                return "0";
            }


        }

    }
}
