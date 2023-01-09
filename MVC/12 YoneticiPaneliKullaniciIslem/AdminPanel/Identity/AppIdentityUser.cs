using AdminPanel.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Identity
{
    public class AppIdentityUser : IdentityUser  // IdentityUserdan miras aldık burada normal bir kullanıcıdaki temel kullanıcı adı ve şifre ile ilgili data barındırılır.
    {

        public int? AdminMi { get; set; }
        public string? AdSoyad { get; set; }
        public int? Durum { get; set; }

        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        public string? LastName { get; set; }

        [Display(Name = "Date of Birth"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? DateofBirth { get; set; }

        [Display(Name = "Mail Gönderme İzni")]
        public int? MailGonderilebilirMi { get; set; }


        [NotMapped]
        public string Role { get; set; }


        public virtual List<SepetUrunler>? SepetUrunler { get; set; }
        public virtual List<Siparisler>? Siparisler { get; set; }
        public virtual List<UyeAdresleri>? UyeAdresleri { get; set; }
        public virtual List<FavoriUrunler>? FavoriUrunler { get; set; }



    }
}
