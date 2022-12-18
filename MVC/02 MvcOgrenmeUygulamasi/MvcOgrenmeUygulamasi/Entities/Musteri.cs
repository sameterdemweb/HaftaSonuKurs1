using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOgrenmeUygulamasi.Entities
{
    [Table("Musteri")] //Bizim verdiğimiz isim ile kullanımı yapılacak ise.
    public class Musteri
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Keywords ve Identy (otomatik artan)
        [Display(Name = "Id Bilgisi")]
        public int Id { get; set; }



        [Display(Name = "Müşteri Adı: ")]//Formlarda Açıklama Olarak Label'da ne yazacağı
        [Required(ErrorMessage = "Müşteri Adı Boş Bırakılamaz")] //Required hata bilgisi boş kalacak ise gelecek hata.
        [StringLength(50,ErrorMessage ="Maksimum 50 Karakter Girebilirsiniz.")]// Maksimum 50 karakter
        public string Adi { get; set; }



        [Display(Name = "Müşteri Soyadı")]
        [Required(ErrorMessage = "Müşteri Soyadı Boş Bırakılamaz")] //Required hata bilgisi boş kalacak ise gelecek hata.
        [StringLength(50, ErrorMessage = "Maksimum 50 Karakter Girebilirsiniz.")]// Maksimum 50 karakter 
        public string Soyadi { get; set; }



        [Display(Name = "Müşteri Yaşı")]
        public int? Yas { get; set; }



        [Display(Name = "Şirket Adı")]
        public string? SirketAdi { get; set; }
    }
}
