using AdminPanel.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Identity
{
    public class AdminPanelContext: IdentityDbContext<AppIdentityUser, AppIdentityRole, string>
    {
        public AdminPanelContext(DbContextOptions<AdminPanelContext> options):base(options)
        {

        }

        public DbSet<AppIdentityUser> AppIdentityUser { get; set; }
        public DbSet<BlogKategorileri> BlogKategorileri { get; set; }
        public DbSet<Bloglar> Bloglar { get; set; }
        public DbSet<UrunKategorileri> UrunKategorileri { get; set; }
        public DbSet<Urunler> Urunler { get; set; }
        public DbSet<UrunFotograflari> UrunFotograflari { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<UyeAdresleri> UyeAdresleri { get; set; }
        public DbSet<UrunParametreleri> UrunParametreleri { get; set; }
        public DbSet<Siparisler> Siparisler { get; set; }
        public DbSet<SiparisDetay> SiparisDetay { get; set; }
        public DbSet<SepetUrunler> SepetUrunler { get; set; }
        public DbSet<FavoriUrunler> FavoriUrunler { get; set; }

    }
}
