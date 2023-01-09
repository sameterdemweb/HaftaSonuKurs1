using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Entities
{

    [Table("Slider")]
    public class Slider
    {
        public Slider()
        {
            Durum = 1;
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Başlık Girin")]
        public string? Baslik { get; set; }

        [Display(Name = "Slider Açıklama Girin")]
        public string? Aciklama { get; set; }

        [Display(Name = "Link bilgisi")]
        public string? Link { get; set; }

        [Required(ErrorMessage = "Boş Bırakamazsınız"), Display(Name = "Durum")]
        public int Durum { get; set; }

        [Display(Name = "Resim Seçin")]
        public string? Resim { get; set; }

        [NotMapped, Display(Name = "ResimDosyasi")]
        public IFormFile? ResimDosya { get; set; }

        [Display(Name = "Mobil Resim Seçin")]
        public string? MobilResim { get; set; }

        [NotMapped, Display(Name = "Mobil Resim Seçin")]
        public IFormFile? MobilResimDosya { get; set; }
    }
}
