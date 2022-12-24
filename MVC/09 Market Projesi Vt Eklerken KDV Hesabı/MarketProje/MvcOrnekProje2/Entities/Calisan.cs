using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOrnekProje2.Entities
{
    [Table("Calisanlar")]
    public class Calisan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id Bilgisi")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan boş bıraklıamaz")]
        [Display(Name = "Çalışanın Adı")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter girilebilir")]
        public string? Adi { get; set; }

        [Required(ErrorMessage = "Bu alan boş bıraklıamaz")]
        [Display(Name = "Çalışanın Soyadı")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter girilebilir")]
        public string? Soyadi { get; set; }

        [Required(ErrorMessage = "Bu alan boş bıraklıamaz")]
        [Display(Name = "Çalışanın Departmanı")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter girilebilir")]
        public string? Departman { get; set; }

        [Display(Name = "Çalışanın Maaşı")]
        public int? Maas { get; set; }
    }
}
