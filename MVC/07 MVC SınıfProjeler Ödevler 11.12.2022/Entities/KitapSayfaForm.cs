using Microsoft.Build.Framework;
using MvcOdev.Services;


namespace MvcOdev.Entities
{
	public class KitapSayfaForm
	{
        public int Id { get; set; }
        [Required]
        public string KitapAdi { get; set; }
        [Required]
        public int KitapSayfasi { get; set; }
        [Required]
        public int HerGunOkunanSayfasi { get; set; }
        [Required]
        public int IlkGunOkunanSayfa { get; set; }
        public int? Gun { get; set; }
    }
}
