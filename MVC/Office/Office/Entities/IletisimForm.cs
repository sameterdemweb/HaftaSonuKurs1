using System.ComponentModel.DataAnnotations;

namespace Office.Entities
{
    public class IletisimForm
    {
        public int Id { get; set; }

        [Required]
        public string AdSoyad { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public string  Konu { get; set; }
        [Required]
        public string Mesaj { get; set; }




    }
}
