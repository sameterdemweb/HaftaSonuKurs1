using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSitePanelim.Entities
{

    [Table("Icerik")]
    public class Icerik
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage ="Boş Bırakılamaz"),Display(Name ="Tur Id")]
        public int TurId { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz"), Display(Name = "Başlık")]

        public string Baslik { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz"), Display(Name = "Kısa Açıklama")]

        public string KisaAciklama { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz"), Display(Name = "Açıklama")]

        public string? Aciklama { get; set; }

        public string? Resim { get; set; }
        public DateTime? Tarih { get; set; }


        [ForeignKey("TurId")]
        public virtual SayfaTuru? SayfaTuru{ get; set; }
    }
}
