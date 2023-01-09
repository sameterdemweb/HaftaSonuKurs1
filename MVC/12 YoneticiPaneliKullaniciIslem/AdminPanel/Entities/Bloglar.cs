using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Entities
{
    [Table("Bloglar")]
    public class Bloglar
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Kategori")]
        public int KategoriId { get; set; }
        [Required, Display(Name = "Durum")]
        public int Durum { get; set; }
        [Required,Display(Name = "Başlık")]
        public string Baslik { get; set; }
        [Display(Name = "Resim Seçin")]
        public string? Resim { get; set; }
        [Display(Name = "Kısa Açıklama")]
        public string? KisaAciklama { get; set; }
        [Required,Display(Name = "İçerik")]
        public string Icerik { get; set; }

        [ForeignKey("KategoriId")]
        public virtual BlogKategorileri? BlogKategori { get; set; }

        [NotMapped,Display(Name = "ResimDosyasi")]
        public IFormFile? ResimDosya { get; set; }

    }
    
}
