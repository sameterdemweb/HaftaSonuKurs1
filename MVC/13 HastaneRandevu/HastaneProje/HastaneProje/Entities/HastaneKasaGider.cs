using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneProje.Entities
{

    [Table("HastaneKasaGider")]
    public class HastaneKasaGider
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz"), Display(Name = "Ücret")]
        public double Ucret { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz"), Display(Name = "Tarih"), DataType(DataType.Date)]
        public DateTime Tarih { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string? Aciklama { get; set; }

    }
}