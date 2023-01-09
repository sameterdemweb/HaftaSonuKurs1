using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Entities
{


    [Table("Urunler")]
    public class Urunler
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Boş Bırakamazsınız"), Display(Name = "Kategori")]
        public int KategoriId { get; set; }


        [Required(ErrorMessage = "Boş Bırakamazsınız"), Display(Name = "Durum")]
        public int Durum { get; set; }


        [Required(ErrorMessage = "Boş Bırakamazsınız"), Display(Name = "Başlık")]
        public string Baslik { get; set; }


        [Required(ErrorMessage = "Boş Bırakamazsınız"), Display(Name = "Standart Fiyat")]
        public double? StandartFiyat { get; set; }

        [Required(ErrorMessage = "Boş Bırakamazsınız"), Display(Name = "Standart Açıklama")]
        public string? StandartAciklama { get; set; }


        [Display(Name = "Top Note"), DataType(DataType.MultilineText)]
        public string? TopNote { get; set; }


        [ Display(Name = "Middle Note"), DataType(DataType.MultilineText)]
        public string? MiddleNote { get; set; }


        [Display(Name = "Base Note"), DataType(DataType.MultilineText)]
        public string? BaseNote { get; set; }


        [Display(Name = "Ana Resim Seçin")]
        public string? Resim { get; set; }


        [Display(Name = "Kısa Açıklama"), DataType(DataType.MultilineText)]
        public string? KisaAciklama { get; set; }


        [Required(ErrorMessage ="Boş Bırakamazsınız"), Display(Name = "İçerik")]
        public string Icerik { get; set; }



        [ForeignKey("KategoriId")]
        public virtual UrunKategorileri? UrunKategori { get; set; }



        [NotMapped, Display(Name = "ResimDosyasi")]
        public IFormFile? ResimDosya { get; set; }



        public virtual List<UrunFotograflari>? Fotograflar { get; set; }
        public virtual List<FavoriUrunler>? FavoriUrunler { get; set; }

        public virtual List<UrunParametreleri>? UrunParametreleri { get; set; }
        public virtual List<SepetUrunler>? SepetUrunler { get; set; }
        public virtual List<SiparisDetay>? SiparisDetay { get; set; }


    }
}
