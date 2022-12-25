using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebSitePanelim.Entities;

namespace WebSitePanelim.Identity
{
    public class AppWebSitePanelDbContext:IdentityDbContext<AppWebSitePanelUser,AppWebSitePanelRole,string>
    {
        public AppWebSitePanelDbContext(DbContextOptions<AppWebSitePanelDbContext>options):base (options)
        {

        }
        public DbSet<Icerik> Icerikler { get; set; }  
        public DbSet<Referans> Referanslar { get; set; }  
        public DbSet<SayfaTuru> SayfaTurleri { get; set; }
    }
}
