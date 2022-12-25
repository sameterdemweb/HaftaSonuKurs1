using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSitePanelim.Entities
{

    [Table("Referans")]
    public class Referans
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz"), Display(Name = "Tarih")]
        public DateTime Tarih { get; set; }

        public string? Url { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz"), Display(Name = "Baslik")]
        public string Baslik { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz"), Display(Name = "Kısa Başlık")]
        public string KisaBaslik { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz"), Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        public string? Resim { get; set; }
    }
}
