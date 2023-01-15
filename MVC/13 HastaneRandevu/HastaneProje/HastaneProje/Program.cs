using HastaneProje.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HastaneProje
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connection = builder.Configuration["Ayarlar:BaglantiSatirim"];
            builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(connection));

            #region Identity User,Role ve DbContext Yap�land�rmas� ve kullan�c� denetimi 

            builder.Services.AddIdentity<AppIdentityUser, AppIdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

            //�ifre kurallar�n� kullan�c�lar i�in tan�ml�yoruz. Kurallar� geli�tirmek
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true; //�ifresinde say�lar zorunlu olsun
                options.Password.RequireNonAlphanumeric = true; //�ifresinde yaz� karakterleri zorunlu olsun
                options.Password.RequireLowercase = true;  //�ifresinde k���k harf zorunlu olsun
                options.Password.RequiredLength = 6; //minimum 6 karakter olsun
                options.Password.RequireUppercase = true; //�ifresinde b�y�k harfte zorunlu olsun

                options.Lockout.MaxFailedAccessAttempts = 5;// 5 kez yanl�� girilirse uzakla�t�r
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // yanl�� girilirse 6 dk uzakla�t�r
                options.Lockout.AllowedForNewUsers = true;//Yeni kullan�c�lar i�inde bu uzakla�t�rma ge�erli.

                options.User.RequireUniqueEmail = true;//Mail ile kay�t olma i�lemi bir mail 1 kez kullan�labilir
                options.SignIn.RequireConfirmedEmail = false;//Mail adresine onaylama gidecek ve onaylama i�lemi yap�l�rsa �yeli�i aktif edilecek.
                options.SignIn.RequireConfirmedPhoneNumber = false; //Telefon numaras�da do�rulanm�� ise giri� yap�labilecek. //False dedik gerek yok telefon onaylamaya
            });

            #endregion

            #region Identity Cookie Ayarlar�n�n yap�land�r�lmas�

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/UyeIslemleri/Giris"; // Kullan�c�n�n login olaca��  sayfa 
                options.LogoutPath = "/UyeIslemleri/Cikis"; // Ki�inin ��k�� yapmas� i�in 
                options.AccessDeniedPath = "/UyeIslemleri/ErisimYetkinizYok"; //ki�inin eri�im yetkisi yoksa y�nlendirilecek sayfa.
                options.SlidingExpiration = true; //Cookie default 20 dk ise 15. dkda sisteme tekkrar girerse20 dk yenilenir
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true, //client scripti vas�tas�ylada eri�im sa�lanabilir.
                    Name = ".AdonetCore.UyeIslemleri.Cookie",
                    Path = "/",
                    //SameSite=SameSiteMode.Strict// Uygulama d���ndan eri�imi cookie iste�i bulunmas�n� engelliyoruz.
                    SameSite = SameSiteMode.Lax// yap�lan istekle ayn� domainde ise �al��abilecek olacak �ekilde gelirse yine kullan�labilir.
                };
            });

            #endregion

            var app = builder.Build();

            #region Giri� ��lemi
            app.UseCookiePolicy();
            app.UseAuthentication();
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