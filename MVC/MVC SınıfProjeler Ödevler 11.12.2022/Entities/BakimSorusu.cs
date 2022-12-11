using System.ComponentModel.DataAnnotations;

namespace MvcOdev.Entities
{
    public class BakimSorusu
    {
        public int Id { get; set; }
        [Required]
        public int CalismaSuresi { get; set; }
        [Required]
        public int BakimGunAraligi { get; set; }
        [Required]
        public double BakimMaliyeti { get; set; }

        public double? ToplamBakimSayisi { get; set; }
        public double? ToplamBakimMaliyeti { get; set; }
    }
}
