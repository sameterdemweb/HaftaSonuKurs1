using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HastaneProje.Identity;

namespace HastaneProje.Entities
{
    [Table("Randevular")]
    public class Randevular
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz"), Display(Name = "Hasta Bilgisi")]
        public string HastaId { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz"), Display(Name = "Doktor Bilgisi")]
        public string DoktorId { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz"), Display(Name = "Saat Bilgisi")]
        public int SaatId { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz"), Display(Name = "Ücret")]
        public double Ucret { get; set; }
        [Display(Name = "Açıklama/Şikayet")]
        public string? Aciklama { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz"), Display(Name = "Tarih"),DataType(DataType.Date)]
        public DateTime Tarih { get; set; }

        [ForeignKey("SaatId")]
        public virtual RandevuSaatleri? RandevuSaati { get; set; }

        [ForeignKey("HastaId")]

      
        public virtual AppIdentityUser? IdentityUserHasta { get; set; }

        [ForeignKey("DoktorId")]
   
        public virtual AppIdentityUser? IdentityUserDoktor { get; set; }
    }
}
