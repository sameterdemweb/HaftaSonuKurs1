using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Entities
{
    [Table("BlogKategorileri")]
    public class BlogKategorileri
    {
        [Key]
        public int Id { get; set; }
        [Required,Display(Name ="Kategori Adı")]
        public string KategoriAdi { get; set; }
        [Required, Display(Name = "Durum")]
        public int Durum { get; set; }
        [Display(Name = "Üst Kategori")]
        public int? UstKategoriId { get; set; }

        [ForeignKey("UstKategoriId")]
        public virtual BlogKategorileri? BlogKategori { get; set; }

        public virtual List<Bloglar>? Bloglar { get; set; }
    }
}
