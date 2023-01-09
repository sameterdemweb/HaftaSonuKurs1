using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Entities
{
    [Table("SiparisDetay")]
    public class SiparisDetay
    {
        [Key]
        public int Id { get; set; }
        public int Adet { get; set; }
        public double Fiyat { get; set; }
        public int SiparisId { get; set; }

        [Display(Name = "Make it a Gift")]
        public bool? PaketDurumu { get; set; }

        [ForeignKey("SiparisId")]
        public virtual Siparisler? Siparis { get; set; }
        public int UrunId { get; set; }
        [ForeignKey("UrunId")]
        public virtual Urunler? Urun { get; set; }

    }
}
