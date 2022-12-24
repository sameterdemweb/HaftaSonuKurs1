using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcOrnekProje2.Entities;

namespace MvcOrnekProje2.Identity
{
    public class AppIdentityDbContext:IdentityDbContext<AppIdentityUser,AppIdentityRole,string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options):base (options)
        {
                
        }

        public DbSet<Musteri> Musteriler { get; set; }

        public DbSet<Calisan> Calisanlar { get; set; }

        public DbSet<Urun> Urunler { get; set; }
    }
}
