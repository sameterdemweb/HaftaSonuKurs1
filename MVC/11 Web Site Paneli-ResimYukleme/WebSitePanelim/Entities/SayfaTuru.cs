using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSitePanelim.Entities
{
    [Table("SayfaTuru")]
    public class SayfaTuru
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage ="Boş Bırakılamaz"),StringLength(60,ErrorMessage ="En Fazla 60 Karakter Yazılabilir")]
        public string Adi { get; set; }


        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public int Durum { get; set; }


        public virtual List<Icerik>? Icerikler { get; set; }

    }
}
