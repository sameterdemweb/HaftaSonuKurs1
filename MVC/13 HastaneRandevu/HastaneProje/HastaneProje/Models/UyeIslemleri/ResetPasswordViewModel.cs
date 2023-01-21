using System.ComponentModel.DataAnnotations;

namespace HastaneProje.Models.UyeIslemleri
{
    public class ResetPasswordViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required] // Submit edilmesi için bu model'den geçiyor olması altındaki Field boş bırakılmadan submit edilemez.
        public string Email { get; set; }

        [DataType(DataType.Password)]//Password olarak Değer tipi gelir
        [Required] // Submit edilmesi için bu model'den geçiyor olması altındaki Field boş bırakılmadan submit edilemez.
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Required] // Submit edilmesi için bu model'den geçiyor olması altındaki Field boş bırakılmadan submit edilemez.
        public string PasswordTekrar { get; set; }
    }
}
