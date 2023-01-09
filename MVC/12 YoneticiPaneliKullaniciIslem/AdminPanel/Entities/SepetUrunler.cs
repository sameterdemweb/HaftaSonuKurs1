using AdminPanel.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Entities
{
    [Table("SepetUrunler")]
    public class SepetUrunler
    {
        public SepetUrunler()
        {
            Adet = 1;   //Default Olarak Adet 1 olacak.
        }
        [Key]
        public int Id { get; set; }
        public string  UserId { get; set; }

        public int  UrunId { get; set; }
        public int  Adet { get; set; }
        public double Ucret { get; set; }

        [Display(Name = "Make it a Gift")]
        public bool? PaketDurumu { get; set; }

        [ForeignKey("UserId")]
        public virtual AppIdentityUser? User { get; set; }

        [ForeignKey("UrunId")]
        public virtual Urunler? Urun { get; set; }
    }
}
