using Microsoft.AspNetCore.Identity;

namespace MvcOgrenmeUygulamasi.Identity
{
    public class ProjeIdentityKullanici : IdentityUser
    {
        public int? Yas { get; set; }
        public string? KisiAciklamasi { get; set; }
    }
}
