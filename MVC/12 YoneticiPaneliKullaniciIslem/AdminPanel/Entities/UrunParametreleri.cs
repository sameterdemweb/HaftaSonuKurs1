using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Entities
{
    [Table("UrunParametreleri")]
    public class UrunParametreleri
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Boş Bırakamazsınız"), Display(Name = "Ürün")]
        public int UrunId { get; set; }


        [Required(ErrorMessage = "Boş Bırakamazsınız"), Display(Name = "Durum")]
        public int Durum { get; set; }


        [Required(ErrorMessage = "Boş Bırakamazsınız"), Display(Name = "Açıklama")]
        public int Aciklama { get; set; }


        [Required(ErrorMessage = "Boş Bırakamazsınız"), Display(Name = "Fiyat Bilgisi")]
        public double Fiyat { get; set; }


        [ForeignKey("UrunId")]
        public virtual Urunler? Urun { get; set; }

     
    }
}
