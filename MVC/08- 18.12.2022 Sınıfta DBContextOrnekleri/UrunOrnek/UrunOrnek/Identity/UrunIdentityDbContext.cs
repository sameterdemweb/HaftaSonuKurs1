using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UrunOrnek.Entities;

namespace UrunOrnek.Identity
{
    public class UrunIdentityDbContext:IdentityDbContext<UrunIdentityUser,UrunIdentityRole,string>
    {
        public UrunIdentityDbContext(DbContextOptions<UrunIdentityDbContext> options):base(options)
        {

        }
        public  DbSet<Urun> Urunler { get; set; }
    }


}
