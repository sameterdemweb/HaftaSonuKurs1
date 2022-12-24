using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutbolcuTakim.Entities
{

    [Table("Takim")]
    public class Takim
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Takım Adı Boş Bırakılamaz"), Display(Name = "Takim Adı")]
        public string Adi { get; set; }


        [Required(ErrorMessage = "Takım Değeri Boş Bırakılamaz"), Display(Name = "Takim Değeri")]
        public double Deger { get; set; }



        [Required(ErrorMessage = "Takım Ligi Boş Bırakılamaz"), Display(Name = "Takim Ligi")]
        public string Lig { get; set; }

        [Required(ErrorMessage = "Takım Ülkesi Boş Bırakılamaz"), Display(Name = "Ülke")]

        public string Ulke { get; set; }

        public virtual List<Futbolcu>? Futbolcular { get; set; }

    }
}
