using Microsoft.EntityFrameworkCore;
using MvcOgrenmeUygulamasi.Identity;

namespace MvcOgrenmeUygulamasi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Configuration methodu ile "appsettings.json" ula��p de�er almak
           // string LocalKodIciBaglanti = "Server=(localdb)\\MSSQLLocalDB;Database=VtAdi;Trusted_Connection=true";
           
            string Baglantim = builder.Configuration["Ayarlar:BaglantiSatirim"]; //appsettings.json �zerinden configuration methoduyla Ayarlar'a eri�im  BaglantiSatirim de�erini al�yoruz. B�ylece cs i�erisinde i�erik tan�mlamam�za gerek yok!.   Configuration Otomatik olarak "appsettings.json" sayfas�na eri�ir.

            #endregion


            #region Veritaban� Connection Kodumuz ve AddDbContext Veritaban�n� Tan�mlama.
            
            
            
            var connection = builder.Configuration["Ayarlar:BaglantiSatirim"];
            builder.Services.AddDbContext<ProjeDbContext>(options => options.UseSqlServer(connection));




            #endregion



            // Add services to the container.
            builder.Services.AddControllersWithViews();





            var app = builder.Build();

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