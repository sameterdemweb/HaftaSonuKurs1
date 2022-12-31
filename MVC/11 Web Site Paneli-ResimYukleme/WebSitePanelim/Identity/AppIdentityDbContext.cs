using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebSitePanelim.Entities;

namespace WebSitePanelim.Identity
{
    public class AppIdentityDbContext:IdentityDbContext<AppIdentityUser,AppIdentityRole,string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options): base (options)
        {

        }

        public DbSet<Icerik> Icerikler { get; set; }

        public DbSet<SayfaTuru> SayfaTuruler { get; set; }

        public DbSet<Referans> Referanslar { get; set; }
    }
}
