using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSitePanelim.Entities
{
    [Table("Icerik")]
    public class Icerik
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz"), StringLength(60, ErrorMessage = "En Fazla 60 Karakter Yazılabilir")]
        public string Baslik { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz"), StringLength(60, ErrorMessage = "En Fazla 60 Karakter Yazılabilir")]
        public string KisaAciklama { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz"), StringLength(60, ErrorMessage = "En Fazla 60 Karakter Yazılabilir")]
        public string Aciklama { get; set; }



        [Display(Name ="Resim")]
        public string? Resim { get; set; }

        [NotMapped, Display(Name = "Resim Seçin")]
        public IFormFile? ResimDosya { get; set; }




        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public DateTime Tarih { get; set; }

        public int TurId { get; set; }

        [ForeignKey("TurId")]
        public virtual SayfaTuru? SayfaTuru { get; set; }
    }
}
