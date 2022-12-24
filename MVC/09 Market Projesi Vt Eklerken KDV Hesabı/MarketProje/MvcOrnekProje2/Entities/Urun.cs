using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MvcOrnekProje2.Entities
{
    [Table("Urunler")]
    public class Urun
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id Bilgisi")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan boş bıraklıamaz")]
        [Display(Name = "Ürün Adı")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter girilebilir")]
        public string? UrunAdi { get; set; }

        [Required(ErrorMessage = "Bu alan boş bıraklıamaz")]
        [Display(Name = "Ürünün Birim Fiyatı")]
        public double BirimFiyat { get; set; }

        [Required(ErrorMessage = "Bu alan boş bıraklıamaz")]
        [Display(Name = "Ürünün Adeti")]
        public int UrunAdet { get; set; }

        [Required(ErrorMessage = "Bu alan boş bıraklıamaz")]
        [Display(Name = "KDV Oranı")]      
        public double KdvOran { get; set; }

        [Display(Name = "KDV'li Fiyat")]
        public double KdvliFiyat { get; set; }

        [Display(Name = "Toplam Fiyat")]
        public double ToplamFiyat { get; set; }
    }
}
