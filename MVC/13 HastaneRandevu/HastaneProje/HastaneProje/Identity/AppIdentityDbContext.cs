using HastaneProje.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HastaneProje.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppIdentityUser , AppIdentityRole , string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options):base(options)
        {

        }
        public DbSet<AppIdentityRole>  IdentityRole { get; set; }
        public DbSet<AppIdentityUser> IdentityUser { get; set; }
        public DbSet<Binalar> Binalar { get; set; }
        public DbSet<Bolumler> Bolumler { get; set; }
        public DbSet<Randevular> Randevular { get; set; }
        public DbSet<RandevuSaatleri> RandevuSaatleri { get; set; }
        public DbSet<HastaneKasaGelir> HastaneKasaGelir { get; set; }
        public DbSet<HastaneKasaGider> HastaneKasaGider { get; set; }
    }
}
