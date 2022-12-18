using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace UrunOrnek.Entities
{
    [Table("Urun")]
    public class Urun
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id Bilgi")]
        public int Id { get; set; }
        
        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "Adı Bırakılamaz")]
        [StringLength(50,ErrorMessage ="Max 50 Karakter")]
        public string Adi { get; set; }
        
        [Display(Name = "Birim Fiyat")]
        [Required(ErrorMessage = "Fiyat Boş Bırakılamaz")]
        public double BirimFiyat { get; set; }

        
        [Display(Name = "Adet Giriniz")]
        [Required(ErrorMessage = "Oyun Fiyatı Boş Bırakılamaz")]
        public int Adet { get; set; }

        public string? Marka { get; set; }
    }
}
