using AdminPanel.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers
{
    public class UyelerController : Controller
    {
        #region UserManager ve SignInManager tanımlarının tanımlanması.
        //Injection yapmak için değişkenlerimizi ilgili tiplerde tanımlıyoruz.
        UserManager<AppIdentityUser> _userManager;

        public UyelerController(UserManager<AppIdentityUser> userManager)//ctor ile yapı denetim bloğu oluşturduk ve içerisinde injection edilen değerlimizi ilgili değişkenlere alıyoruz artık bu değişkenler üzerinden işlemlerimizi gerçekleştirebiliriz.
        {
            _userManager = userManager;
        }
        #endregion

        public IActionResult Index()
        {

            IEnumerable<AppIdentityUser> uyeler = _userManager.Users.Where(u => u.AdminMi != 1);
            return View(uyeler);

            //return View(_userManager.Users.Where(u=>u.AdminMi!=1));
        }
    }
}
