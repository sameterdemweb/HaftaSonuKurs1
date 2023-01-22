using HastaneProje.Entities;
using HastaneProje.Identity;

namespace HastaneProje
{
    public class BolumveDoktorViewModel
    {
        public Bolumler Bolumler { get; set; }
        public List<AppIdentityUser> Doktorlar { get; set; }
    }
}