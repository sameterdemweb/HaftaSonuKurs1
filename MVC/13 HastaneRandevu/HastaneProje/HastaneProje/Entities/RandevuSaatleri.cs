using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneProje.Entities
{
    [Table("RandevuSaatleri")]
    public class RandevuSaatleri
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required,DisplayName("Randevu Saatleri"),StringLength(20)]
        public string RandevuSaati { get; set; }

        public virtual List<Randevular>? Randevular { get; set; }

    }
}
