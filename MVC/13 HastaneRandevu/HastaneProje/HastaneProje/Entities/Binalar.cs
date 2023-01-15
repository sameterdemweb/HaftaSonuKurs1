using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneProje.Entities
{
    [Table("Binalar")]
    public class Binalar
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu alan boş bırakılamaz"), Display(Name = "Bina Adı"), StringLength(50)]

        public string BinaAdi { get; set; }

        public virtual List<Bolumler>? Bolumler { get; set; }

    }
}
