using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOgrenmeUygulamasi.Entities
{
    [Table("Calisan")] //Bizim verdiğimiz isim ile kullanımı yapılacak ise.
    public class Calisan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Keywords ve Identy (otomatik artan)
        [Display(Name = "Id Bilgisi")]
        public int Id { get; set; }



        [Display(Name = "Çalışan Adı: ")]//Formlarda Açıklama Olarak Label'da ne yazacağı
        [Required(ErrorMessage = "Çalışan Adı Boş Bırakılamaz")] //Required hata bilgisi boş kalacak ise gelecek hata.
        [StringLength(50, ErrorMessage = "Maksimum 50 Karakter Girebilirsiniz.")]// Maksimum 50 karakter
        public string Adi { get; set; }



        [Display(Name = "Çalışan Soyadı")]
        [Required(ErrorMessage = "Çalışan Soyadı Boş Bırakılamaz")] //Required hata bilgisi boş kalacak ise gelecek hata.
        [StringLength(50, ErrorMessage = "Maksimum 50 Karakter Girebilirsiniz.")]// Maksimum 50 karakter 
        public string Soyadi { get; set; }


        [Display(Name = "Çalışan Yaşı")]
        public int? Yas { get; set; }

        public double? Maas { get; set; }
    }
}
