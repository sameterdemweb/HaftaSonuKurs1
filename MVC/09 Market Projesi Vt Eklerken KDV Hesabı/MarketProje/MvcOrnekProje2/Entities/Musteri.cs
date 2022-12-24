using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOrnekProje2.Entities
{
    [Table("Musteriler")]
    public class Musteri
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Id Bilgisi")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Bu alan boş bıraklıamaz")]
        [Display(Name ="Müşterinin Adı")]
        [StringLength(50, ErrorMessage ="Maksimum 50 karakter girilebilir")]
        public string? Adi { get; set; }

        [Required(ErrorMessage = "Bu alan boş bıraklıamaz")]
        [Display(Name = "Müşterinin Soyadı")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter girilebilir")]
        public string? Soyadi { get; set; }

        [Required(ErrorMessage = "Bu alan boş bıraklıamaz")]
        [Display(Name = "Müşterinin Telefon Numarası")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter girilebilir")]
        public string? Telefon { get; set; }

        [Display(Name = "Müşterinin Adresi")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter girilebilir")]
        public string? Adres { get; set; }
    }
}
