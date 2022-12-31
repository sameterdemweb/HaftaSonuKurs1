using Microsoft.EntityFrameworkCore;
using WebSitePanelim.Identity;

namespace WebSitePanelim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connection = builder.Configuration["Ayarlar:BaglantiSatirim"];
            builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(connection));





            // Add services to the container.
            builder.Services.AddControllersWithViews();


            #region Session Kullanýmý için Bu 'AddSession' eklemeliyiz.
            builder.Services.AddDistributedMemoryCache();  // Uygulama sunucusunun hafýzasýnda tutulacak bir ortam tanýmlanýyor.
            builder.Services.AddSession();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);//Süre Belirleme Yapabiliyoruz. Default ola rak 20 dk
            });
            #endregion

            var app = builder.Build();

            #region session servisini aktif ediyoruz
            app.UseSession();// Build ettikten sonra session servisi entegrasyonumuzu yaptýk
            #endregion

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}