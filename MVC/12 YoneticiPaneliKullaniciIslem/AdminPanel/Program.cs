using AdminPanel.Identity;
using AdminPanel.Repository;
using AdminPanel.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



#region Dependency Injection

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion


#region Veritabaný Connection Kodumuz ve AddDbContext Veritabanýný Tanýmlama. Ve Veri Atma Kodlarýmýz
var connection = builder.Configuration["Ayarlar:BaglantiSatirim"];
builder.Services.AddDbContext<AdminPanelContext>(options => options.UseSqlServer(connection));

#endregion

#region Identity User,Role ve DbContext Yapýlandýrmasý ve kullanýcý denetimi 

builder.Services.AddIdentity<AppIdentityUser, AppIdentityRole>().AddEntityFrameworkStores<AdminPanelContext>().AddDefaultTokenProviders();

//Þifre kurallarýný kullanýcýlar için tanýmlýyoruz. Kurallarý geliþtirmek
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true; //þifresinde sayýlar zorunlu olsun
    options.Password.RequireNonAlphanumeric = true; //þifresinde yazý karakterleri zorunlu olsun
    options.Password.RequireLowercase = true;  //þifresinde küçük harf zorunlu olsun
    options.Password.RequiredLength = 6; //minimum 6 karakter olsun
    options.Password.RequireUppercase = true; //þifresinde büyük harfte zorunlu olsun

    options.Lockout.MaxFailedAccessAttempts = 5;// 5 kez yanlýþ girilirse uzaklaþtýr
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // yanlýþ girilirse 6 dk uzaklaþtýr
    options.Lockout.AllowedForNewUsers = true;//Yeni kullanýcýlar içinde bu uzaklaþtýrma geçerli.

    options.User.RequireUniqueEmail = true;//Mail ile kayýt olma iþlemi bir mail 1 kez kullanýlabilir
    options.SignIn.RequireConfirmedEmail = false;//Mail adresine onaylama gidecek ve onaylama iþlemi yapýlýrsa üyeliði aktif edilecek.
    options.SignIn.RequireConfirmedPhoneNumber = false; //Telefon numarasýda doðrulanmýþ ise giriþ yapýlabilecek. //False dedik gerek yok telefon onaylamaya
});

#endregion

#region Identity Cookie Ayarlarýnýn yapýlandýrýlmasý

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Guvenlik/Giris"; // Kullanýcýnýn login olacaðý  sayfa 
    options.LogoutPath = "/Guvenlik/Cikis"; // Kiþinin çýkýþ yapmasý için 
    options.AccessDeniedPath = "/Guvenlik/ErisimYetkinizYok"; //kiþinin eriþim yetkisi yoksa yönlendirilecek sayfa.
    options.SlidingExpiration = true; //Cookie default 20 dk ise 15. dkda sisteme tekkrar girerse20 dk yenilenir
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true, //client scripti vasýtasýylada eriþim saðlanabilir.
        Name = ".AdonetCore.Guvenlik.Cookie",
        Path = "/",
        //SameSite=SameSiteMode.Strict// Uygulama dýþýndan eriþimi cookie isteði bulunmasýný engelliyoruz.
        SameSite = SameSiteMode.Lax// yapýlan istekle ayný domainde ise çalýþabilecek olacak þekilde gelirse yine kullanýlabilir.
    };
});

#endregion

#region Session Kullanýmý için Bu 'AddSession' eklemeliyiz.
builder.Services.AddDistributedMemoryCache();  // Uygulama sunucusunun hafýzasýnda tutulacak bir ortam tanýmlanýyor.
builder.Services.AddSession();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);//Süre Belirleme Yapabiliyoruz. Default ola rak 20 dk
});
#endregion


var app = builder.Build();

#region  Servis olarak build etmeden önce tanýmladýðýmýz session servisini aktif ediyoruz
app.UseSession();// Build ettikten sonra session servisi entegrasyonumuzu yaptýk
#endregion

#region Giriþ Ýþlemi
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
