using HastaneProje.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace HastaneProje.Identity
{
    public class AppIdentityUser : IdentityUser
    {
        public string? Resim { get; set; }

        [Display(Name ="Adı Soyadı")]
        public string? AdSoyad { get; set; }

        [Display(Name = "Bölüm Bilgisi")]
        public int? BolumId { get; set; }

        [Display(Name = "Cinsiyet")]
        public string? Cinsiyet { get; set; }

        [Display(Name = "Cinsiyet")]
        [NotMapped]
        public virtual List<Randevular>? HastaRandevulari { get; set; }

        [ForeignKey("BolumId")]
        public virtual Bolumler? Bolum { get; set; }

        [NotMapped]
        public IFormFile? ResimDosyasi { get; set; }

    }
}
