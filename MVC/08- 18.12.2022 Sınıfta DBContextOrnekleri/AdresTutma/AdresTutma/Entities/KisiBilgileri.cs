using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdresTutma.Entities
{
    [Table("AdresTutma")]
    public class KisiBilgileri
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Id Bilgisi")]
        public int Id { get; set; }

        [Display(Name ="Kişi Adı")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        [StringLength(50,ErrorMessage ="Maksimum 50 karakter girilebilir")]
        public string Adi { get; set; }

        [Display(Name = "Kişi Soyadı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(50, ErrorMessage = "Maksimum 50 karakter girilebilir")]
        public string Soyadi { get; set; }

        [Display(Name = "Kişi Adresi")]
        public string? Adres { get; set; }

        [Display(Name = "Kişi Telefon Numarası")]
        public string? TelefonNo { get; set; }
    }
}
