using FutbolcuTakim.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FutbolcuTakim.Identity
{
    public class AppUygulamaDbContext : IdentityDbContext<AppUygulamaUser, AppUygulamaRole, string>
    {
        public AppUygulamaDbContext(DbContextOptions<AppUygulamaDbContext> options) : base(options)
        {

        }
        public DbSet<Futbolcu> Futbolcular { get; set; }
        public DbSet<Takim> Takimlar { get; set; }
    }
}
