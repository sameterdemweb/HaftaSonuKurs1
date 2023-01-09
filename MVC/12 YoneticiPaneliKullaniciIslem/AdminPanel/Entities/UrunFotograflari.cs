using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Entities
{
    [Table("UrunFotograflari")]
    public class UrunFotograflari
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Boş Bırakamazsınız"), Display(Name = "Ürün")]
        public int UrunId { get; set; }

        [Required(ErrorMessage = "Boş Bırakamazsınız"), Display(Name = "Durum")]
        public int Durum { get; set; }

        [Display(Name = "Resim Seçin")]
        public string? Resim { get; set; }

        [ForeignKey("UrunId")]
        public virtual Urunler? Urun { get; set; }

        [NotMapped, Display(Name = "ResimDosyasi")]
        public IFormFile ResimDosya { get; set; }
    }
}
