using AdresTutma.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdresTutma.Identity
{
    public class AppIdentityDbContext:IdentityDbContext<AppIdentityUser,AppIdentityRole,string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext>options): base(options)
        {

        }

        public DbSet<KisiBilgileri> KisiBilgileri { get; set; }
    }
}
