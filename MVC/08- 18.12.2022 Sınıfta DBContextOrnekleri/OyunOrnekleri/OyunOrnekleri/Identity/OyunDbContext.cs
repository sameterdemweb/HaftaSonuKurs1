using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OyunOrnekleri.Entities;

namespace OyunOrnekleri.Identity
{
    public class OyunDbContext:IdentityDbContext<OyunKullanici,OyunRole,string>
    {
        public OyunDbContext(DbContextOptions<OyunDbContext> options):base(options)
        {

        }
        public DbSet<Oyun> Oyunlar { get; set; }
    }
}
