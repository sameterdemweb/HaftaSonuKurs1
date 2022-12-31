using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSitePanelim.Entities
{
    [Table("Referans")]
    public class Referans
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Id Bilgisi")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz"), StringLength(60, ErrorMessage = "En Fazla 60 Karakter Yazılabilir")]
        [Display(Name = "Başlık")]
        public string Baslik { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string Resim { get; set; }

        public string Url { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }


        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [Display(Name = "Kısa Açıklama")]
        public string KisaAciklama { get; set; }

        public DateTime Tarih { get; set; }
    }
}
