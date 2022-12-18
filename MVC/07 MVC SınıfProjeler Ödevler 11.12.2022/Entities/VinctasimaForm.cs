using Microsoft.Build.Framework;

namespace MvcOdev.Entities
{
    public class VinctasimaForm
    {
        public int Id { get; set; }
        [Required]
        public string? VincAdi { get; set; }
        [Required]
        public int KacMetreGidecek { get; set; }
        [Required]
        public int HerMetredeKayipKg { get; set; }
        [Required]
        public int YuklenenKg { get; set; }

        public int? KalanKg { get; set; }


    }
}
