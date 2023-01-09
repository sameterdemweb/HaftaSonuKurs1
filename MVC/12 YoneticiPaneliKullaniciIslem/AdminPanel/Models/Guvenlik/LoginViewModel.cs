using System.ComponentModel.DataAnnotations;

namespace AdminPanel.Models.Guvenlik
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Kullanıcı Adınız")]
        [Required] // Submit edilmesi için bu model'den geçiyor olması altındaki Field boş bırakılmadan submit edilemez.
        public string UserName { get; set; }

        [Display(Name = "Şifreniz")]
        [DataType(DataType.Password)]
        [Required] // Submit edilmesi için bu model'den geçiyor olması altındaki Field boş bırakılmadan submit edilemez.
        public string Password { get; set; }
    }
}