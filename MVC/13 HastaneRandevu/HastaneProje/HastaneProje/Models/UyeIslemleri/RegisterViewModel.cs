using System.ComponentModel.DataAnnotations;

namespace HastaneProje.Models.UyeIslemleri
{
    public class RegisterViewModel
    {
        public int Id { get; set; }

        [Display(Name = "TC Kimlik No / Pasaport Numaranız")]
        [Required]
        public string UserName { get; set; }


        [Display(Name = "Adı Soyadı")]
        [Required]
        public string AdSoyad { get; set; }


        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]//Password olarak Değer tipi gelir
        [Required] // Submit edilmesi için bu model'den geçiyor olması altındaki Field boş bırakılmadan submit edilemez.
        public string Password { get; set; }


        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Required] // Submit edilmesi için bu model'den geçiyor olması altındaki Field boş bırakılmadan submit edilemez.
        public string PasswordTekrar { get; set; }


        [Display(Name = "E-Posta Adresi")]
        [DataType(DataType.EmailAddress)]
        [Required] // Submit edilmesi için bu model'den geçiyor olması altındaki Field boş bırakılmadan submit edilemez.
        public string Email { get; set; }

        public int? BolumId { get; set; }

    }
}
