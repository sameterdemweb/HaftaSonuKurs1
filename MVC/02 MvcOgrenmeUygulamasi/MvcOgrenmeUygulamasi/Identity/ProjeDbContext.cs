
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcOgrenmeUygulamasi.Entities;

namespace MvcOgrenmeUygulamasi.Identity
{
  
    public class ProjeDbContext : IdentityDbContext<ProjeIdentityKullanici, ProjeKullaniciYetkileri, string>
    {

        public ProjeDbContext(DbContextOptions<ProjeDbContext> options):base(options)
        {

        }

        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<Calisan> Calisan { get; set; }
    }
}
