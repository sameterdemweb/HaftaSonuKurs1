using AdminPanel.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Entities
{
    [Table("Siparisler")]
    public class Siparisler
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }

       
        public DateTime SiparisTarihi { get; set; }
        public double SiparisTutari { get; set; }
        public string SiparisDurumu { get; set; }
     
        public int? AdresId { get; set; }

        public string? AdresBaslik { get; set; }
        public string? Address { get; set; }
        public string? PostaKodu { get; set; }
        public string? Telefon { get; set; }

        [ForeignKey("AdresId")]
        public virtual UyeAdresleri? UyeAdres { get; set; }

        public virtual List<SiparisDetay>? SiparisDetay { get; set; }

        [ForeignKey("UserId")]
        public virtual AppIdentityUser? User { get; set; }




    }
}
