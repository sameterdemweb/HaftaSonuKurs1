using HastaneProje.Entities;
using HastaneProje.Identity;
using HastaneProje.Models;

namespace HastaneProje
{
    public class DoktorRandevuSaatleriViewModel
    {
        public List<RandevuSaatleri> Saatler { get; set; }

        public RandevuTarihSaatViewModel DoktorTarihBilgi { get; set; }

        public  AppIdentityDbContext Context { get; set; }

        

    }
}