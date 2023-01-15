using HastaneProje.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneProje.Entities
{
    [Table("Bolumler")]
    public class Bolumler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz"), Display(Name = "Bölüm Adı"),StringLength(50)]

        public string BolumAdi { get; set; }

        public int BinaId { get; set; }
        [ForeignKey("BinaId") ]
        public virtual Binalar? Bina { get; set; }
        public virtual List<AppIdentityUser>? Doktorlar { get; set; }

    }
}
