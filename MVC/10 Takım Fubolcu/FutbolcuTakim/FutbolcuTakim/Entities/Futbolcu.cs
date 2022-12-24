using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace FutbolcuTakim.Entities
{
    [Table("Futbolcu")]
    public class Futbolcu
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Futbolcu Adı Boş Bırakılamaz"), Display(Name = "Futbolcu Adı")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Futbolcu Soyadı Boş Bırakılamaz"), Display(Name = "Futbolcu Soyadı")]
        public string Soyadi { get; set; }


        [Required(ErrorMessage = "Futbolcu Değeri Boş Bırakılamaz"), Display(Name = "Futbolcu Değeri")]
        public double Deger { get; set; }

        [Required(ErrorMessage = "Futbolcu Ülkesi Boş Bırakılamaz"), Display(Name = "Doğduğu Ülke")]

        public string Ulke { get; set; }
        [Display(Name ="Takım")]
        public int TakimId { get; set; }

        [ForeignKey("TakimId")]
        public virtual Takim? Takim { get; set; }
    }
}
