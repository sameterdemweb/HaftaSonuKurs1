using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OyunOrnekleri.Entities
{
    [Table("Oyun")]
    public class Oyun
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Id Bilgi")]
        public int Id { get; set; }


    
        [Display(Name ="Oyun Adı")]
        [Required(ErrorMessage ="Oyun Adı Boş Bırakılamaz")]
        public string Adi { get; set; }

        [Display(Name ="Oyun Fiyat")]
        [Required(ErrorMessage = "Oyun Fiyatı Boş Bırakılamaz")]
        public int Fiyat { get; set; }


        [Display(Name = "Yapımcı")]
        [Required(ErrorMessage = "Yapımcı Boş Bırakılamaz")]
        public string Yapimci { get; set; }
        public int? Indirme { get; set; }
    }
}
