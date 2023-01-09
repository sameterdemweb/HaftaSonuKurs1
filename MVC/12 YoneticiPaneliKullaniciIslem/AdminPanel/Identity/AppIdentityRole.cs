using Microsoft.AspNetCore.Identity;

namespace AdminPanel.Identity
{
    public class AppIdentityRole : IdentityRole
    {
        public string KullaniciTipi { get; set; }
    }
}
